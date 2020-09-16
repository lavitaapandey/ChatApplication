

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public partial class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
    }
}
