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
        public int Email { get; set; }

        public RegisterUserEventRequest(int id , int email)
        {
            Id = id;
            Email = email;
        }
    }
}
