
using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Repository
{

    public interface IChatRepository
    {

        Task<string> getReceiverName(string ReceiverID);
        Task<object> saveUserChat(vmMessage _model);
        Task<List<UserChat>> getUserChat(UserChat model);
        Task<List<Group>> getAllGroups(int userID);
        Task<List<UserLogin>> getAllUsers();
        Group postGroupDetail(Group group);
        


    }
}
