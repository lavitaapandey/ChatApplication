using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;
using ChatApplication.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatApplication.Controllers
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class chatController : ControllerBase
    {
       
        private readonly IChatRepository _chatRepository;

        public chatController(IChatRepository productRepository)
        {
            _chatRepository = productRepository;
        }



        //GET: api/chat/userChat
        [HttpGet("[action]")]
        public async Task<object> userChat([FromQuery] string param)
        {
            object result = null; object resdata = null;

            try
            {
                if (param != string.Empty)
                {
                    dynamic data = JsonConvert.DeserializeObject(param);
                    UserChat model = JsonConvert.DeserializeObject<UserChat>(data.ToString());
                    if (model != null)
                    {
                        resdata = await _chatRepository.getUserChat(model);
                    }
                }
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

        [HttpGet("[action]")]
        public async Task<object> getAllGroups(int userID)
        {
            object result = null; object resdata = null;

            try
            {



                resdata = await _chatRepository.getAllGroups(userID);


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
        [HttpGet("[action]")]
        public async Task<object> getAllUsers()
        {
            object result = null; object resdata = null;

            try
            {



                resdata = await _chatRepository.getAllUsers();


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
        [HttpPost("[action]")]
        public async Task<vmGroup>  postGroupDetail(vmGroup group)
        {
            string Id = group.userId.ToString();
            Group grp = new Group();
            grp.groupName = group.groupName;
            var tempList = new List<string>();
            tempList.Add(Id);
            foreach (var participant in group.groupParticipants)
            {
                tempList.Add(participant.userId.ToString()) ;

            }
            grp.groupParticipants = String.Join(",", tempList);
           
            _chatRepository.postGroupDetail(grp);
            return group;
        }
    }
}
