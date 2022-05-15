using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Model
{
    public class LoginData
    {
        public string username { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public Int32 edad { get; set; }
        public string rol { get; set; }
    }
}
