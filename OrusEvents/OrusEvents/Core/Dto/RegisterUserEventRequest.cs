using OrusEvents.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class RegisterUserEventRequest : IUseCaseRequest<RegisterUserEventResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public RegisterUserEventRequest(int id , string email)
        {
            Id = id;
            Email = email;
        }
    }
}
