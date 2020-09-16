using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Repository
{
    public class userRepository : IUserRepository
    {
        private readonly ChatContext _ctx;

        public userRepository(ChatContext dbContext)
        {
            _ctx = dbContext;
        }
        public async Task<object> getUserlogin(UserLogin model)
        {
            var loggeduser = (dynamic)null;
            try
            {
               
                    loggeduser = await (from x in _ctx.UserLogin
                                        where x.UserName == model.UserName && x.UserPass == model.UserPass
                                        select x).FirstOrDefaultAsync();
               

            }
            catch (Exception ex)
            {
                ex.ToString();
                loggeduser = null;
            }

            return loggeduser;
        }

    }
}

