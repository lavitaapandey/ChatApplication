

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;
using ChatApplication.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ChatApplication.Controllers
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class authController : ControllerBase
    {
        //private DataAccess _objAuthtication = null;

        //public userController()
        //{
        //    this._objAuthtication = new DataAccess();
        //}
        private readonly IUserRepository _userRepository;

        public authController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        //POST: api/user/userlogin
        [HttpPost("[action]")]
        public async Task<object> userlogin([FromBody] UserLogin model)
        {
            object result = null; object resdata = null;

            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                //Login
                resdata = await _userRepository.getUserlogin(model);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            result = new
            {
                resdata
            };

            return result;
        }
    }
}
