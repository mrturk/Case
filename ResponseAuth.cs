using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case
{
    public class ResponseAuth
    {
        //validation-specific object class for response
        public string user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string token { get; set; }

    }
}
