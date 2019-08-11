using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Controllers.Models
{
    public class GetRegisterInfoResponse
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public bool Payed { get; set; }
        public string UserEmail { get; set; }
    }
}
