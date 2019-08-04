using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class RegisterUserEventResponse : BaseResponse
    {
        public Guid IdRegister { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public RegisterUserEventResponse(IEnumerable<string> errors, bool success = false, string message = null)
            : base(success, message)
        {
            Errors = errors;
        }

        public RegisterUserEventResponse(Guid idRegister, bool success = false, string message = null) 
            : base(success, message)
        {
            IdRegister = idRegister;
        }
    }
}
