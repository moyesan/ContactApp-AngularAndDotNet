using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Entities
{
    public class Login
    {
        public string? UserName
        {
            get;
            set;
        }
        public string? Password
        {
            get;
            set;
        }
    }

    public class JWTTokenResponse
    {
        public string? Token
        {
            get;
            set;
        }
    }
}
