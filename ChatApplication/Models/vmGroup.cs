using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public class vmGroup
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        //public string groupParticipants { get; set; }
        public List<participantViewModel> groupParticipants { get; set; }
        public int userId { get; set; }

    }
    public class participantViewModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
    }
}
