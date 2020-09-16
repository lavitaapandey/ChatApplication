using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public class Group
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupParticipants { get; set; }
    }
}
