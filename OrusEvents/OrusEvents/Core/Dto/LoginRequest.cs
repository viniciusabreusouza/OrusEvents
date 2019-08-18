using OrusEvents.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        public string User { get; set; }
        public string Password { get; set; }
        public LoginRequest(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
