using OrusEvents.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class RegisterConfirmationEventRequest : IUseCaseRequest<RegisterConfirmationEventResponse>
    {
        public Guid RegisterId { get; set; }

        public RegisterConfirmationEventRequest(Guid registerId)
        {
            RegisterId = registerId;
        }
    }
}
