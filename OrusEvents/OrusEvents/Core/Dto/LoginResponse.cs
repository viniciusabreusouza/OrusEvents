using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class LoginResponse : BaseResponse
    {
        public int UserId { get; set; }
    
        public IEnumerable<string> Errors { get; set; }

        public LoginResponse(IEnumerable<string> errors, bool success = false, string message = null)
           : base(success, message)
        {
            Errors = errors;
        }

        public LoginResponse(int userId, bool success = false, string message = null)
            : base(success, message)
        {
            UserId = userId;
        }
    }
}
