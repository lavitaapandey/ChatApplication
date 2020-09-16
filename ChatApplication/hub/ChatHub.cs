
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;
using ChatApplication.Repository;

namespace ChatApplication.hub
{

    public class ChatHub : Hub
    {

        private readonly IChatRepository _chatRepository;

        public ChatHub(IChatRepository productRepository)
        {
            _chatRepository = productRepository;
        }

        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
       

        public async Task SendMessage(vmMessage _message)
        {
            string[] splitReceiverid = null;
            //string[] ReceiverID = null;
            List<string> ReceiverID = new List<string>();
            if (_message.Receiverid.Contains(','))
            {
                splitReceiverid = _message.Receiverid.Split(',');
                foreach (string receiverID in splitReceiverid)
                {
                 //   _objData = new IChatRepository();
                    string ReceiverName = await _chatRepository.getReceiverName(receiverID);
                    ReceiverID.Add(ReceiverName);
                }
                var x = string.Join(", ", ReceiverID);
                try
                {

                    _message.Receiverid = x;
                    //_message.Connectionid = String.Join(",", ReceiverConnectionids);
                    await _chatRepository.saveUserChat(_message);
                   
                        await Clients.All.SendAsync("ReceiveMessage", _message);
                   
                    
                    //await Clients.Clients(ReceiverConnectionids).SendAsync("ReceiveMessage", _message);
                }
                catch (Exception) { }
                //}


            }
            else
            {
                //Receive Message
                List<string> ReceiverConnectionids = _connections.GetConnections(_message.Receiverid).ToList<string>();
                //if (ReceiverConnectionids.Count() > 0)
                //{
                //Save-Receive-Message
                try
                {
                   // _objData = new DataAccess();
                    _message.IsPrivate = true;
                    // _message.Connectionid = String.Join(",", ReceiverConnectionids);
                    await _chatRepository.saveUserChat(_message);
                    //await Clients.Users(_message.Receiverid).SendAsync("ReceiveMessage", _message);
                    //await Clients.All.SendAsync("ReceiveMessage", _message);
                     await Clients.Clients(ReceiverConnectionids).SendAsync("ReceiveMessage", _message);
                }
                catch (Exception) { }
                //}
            }

        }


        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                try
                {
                    //Add Logged User
                    var userName = httpContext.Request.Query["user"].ToString();
                    // var userID = httpContext.Request.Query["userId"].ToString(); 
                    //var UserAgent = httpContext.Request.Headers["User-Agent"].FirstOrDefault().ToString();
                    var connId = Context.ConnectionId.ToString();
                    _connections.Add(userName, connId);

                    //Update Client
                    await Clients.All.SendAsync("UpdateUserList", _connections.ToJson());
                }
                catch (Exception) { }
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                //Remove Logged User
                var username = httpContext.Request.Query["user"];
                _connections.Remove(username, Context.ConnectionId);

                //Update Client
                await Clients.All.SendAsync("UpdateUserList", _connections.ToJson());
            }

            //return base.OnDisconnectedAsync(exception);
        }
    }
}
