using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class GetRegisterInfoResponse : BaseResponse
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public bool Payed { get; set; }
        public string UserEmail { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public GetRegisterInfoResponse(IEnumerable<string> errors, bool success = false, string message = null)
           : base(success, message)
        {
            Errors = errors;
        }

        public GetRegisterInfoResponse(int eventId, string eventName, DateTime date, bool payed, string userEmail, bool success = false, string message = null)
            : base(success, message)
        {
            EventId = eventId;
            EventName = eventName;
            EventDate = date;
            Payed = payed;
            UserEmail = userEmail;
        }
    }
}
