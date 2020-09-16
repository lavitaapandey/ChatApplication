using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Repository
{
   
    public class chatRepository : IChatRepository
    {
        private readonly ChatContext _ctx;

        public chatRepository(ChatContext dbContext)
        {
            _ctx = dbContext;
        }
        public async Task<string> getReceiverName(string ReceiverID)
        {
            string ReceiverName = string.Empty;
            int Receiver = Convert.ToInt32(ReceiverID);

            try
            {
               
                    return _ctx.UserLogin.FirstOrDefault(x => x.UserId == Receiver).UserName;
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<object> saveUserChat(vmMessage _model)
        {
            string message = string.Empty;
            try
            {
               
                    UserChat model = new UserChat()
                    {
                        Chatid = _ctx.UserChat.DefaultIfEmpty().Max(x => x == null ? 0 : x.Chatid) + 1,
                        Connectionid = _model.Connectionid,
                        Senderid = _model.Senderid,
                        Receiverid = _model.Receiverid,
                        Message = _model.Message,
                        Messagestatus = _model.Messagestatus,
                        Messagedate = _model.Messagedate,
                        IsGroup = _model.IsGroup,
                        IsPrivate = _model.IsPrivate,
                        IsMultiple = _model.IsMultiple,
                        groupId = _model.groupId
                    };
                    _ctx.UserChat.Add(model);
                    await _ctx.SaveChangesAsync();
                    message = "Saved";



               
            }
            catch (Exception ex)
            {
                message = "Error:" + ex.ToString();
            }
            return message;
        }

        public async Task<List<UserChat>> getUserChat(UserChat model)
        {
            //List<UserChat> userChats = new List<UserChat>();
            if (model.Receiverid.Contains(','))
            {
                //    string ReceiverName = "";
                //    string[] splitReceiverid = model.Receiverid.Split(',');
                //    foreach (var receiverId in splitReceiverid)
                //    {
                //        int receiver = Convert.ToInt32(receiverId);
                //        using (_ctx = new SignalRChatContext())
                //        {

                //            ReceiverName= _ctx.UserLogin.FirstOrDefault(x => x.UserId == receiver).UserName;
                //        }
                //string ReceiverName = getReceiverName(receiverId);
                List<UserChat> userChat = null;
                try
                {
                    
                        userChat = (from x in _ctx.UserChat
                                    where (x.groupId == model.groupId)
                                    select x).ToList();
                   
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    userChat = null;
                }
                //        userChats.AddRange(userChat);



                //}
                return userChat;

            }
            else
            {
                List<UserChat> userChat = null;
                try
                {
                   
                        userChat = (from x in _ctx.UserChat
                                    where ((x.Senderid == model.Senderid && x.Receiverid == model.Receiverid) || (x.Receiverid == model.Senderid && x.Senderid == model.Receiverid) && x.IsPrivate == true)
                                    select x).ToList();
                   
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    userChat = null;
                }

                return userChat;

            }

        }
        public Task<List<Group>> getAllGroups(int userID)
        {
            string _userID = userID.ToString();
            return Task.Run(() =>
            {
                List<Group> group = null;
                try
                {
                    
                        group = (from x in _ctx.Group
                                 where (x.groupParticipants.Contains(_userID))

                                 select x).ToList();
                    
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    group = null;
                }

                return group;
            });
        }
        public Task<List<UserLogin>> getAllUsers()
        {
            return Task.Run(() =>
            {
                List<UserLogin> users = null;
                try
                {
                   
                        users = (from x in _ctx.UserLogin

                                 select x).ToList();
                    
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    users = null;
                }

                return users;
            });
        }

       public Group postGroupDetail(Group group)
        {
            if (group!=null)
            {
                _ctx.Group.Add(group);
                _ctx.SaveChanges();
                return group;
            }
            return null;
        }

    }
}
