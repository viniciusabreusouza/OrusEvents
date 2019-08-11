using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class RegisterConfirmationEventResponse : BaseResponse
    {
        public bool Confirmation { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public RegisterConfirmationEventResponse(IEnumerable<string> errors, bool success = false, string message = null)
           : base(success, message)
        {
            Errors = errors;
        }

        public RegisterConfirmationEventResponse(bool confirmation, bool success = false, string message = null)
            : base(success, message)
        {
            Confirmation = confirmation;
        }
    }
}
