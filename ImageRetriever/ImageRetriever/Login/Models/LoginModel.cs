using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.Login.Models
{
    public class LoginModel
    {
        public class UserLoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string JWTToken { get; set; }
            public int Id { get; set; }
        }
    }
}
