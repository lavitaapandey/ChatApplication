//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ChatApplication.Repository
//{
//    interface IUserRepository
//    {
//    }
//}

using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Repository
{

    public interface IUserRepository
    {
         Task<object> getUserlogin(UserLogin model);
    }
}
