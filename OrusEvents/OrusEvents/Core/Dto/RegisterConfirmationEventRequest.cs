using OrusEvents.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class RegisterConfirmationEventRequest : IUseCaseRequest<RegisterConfirmationEventResponse>
    {
        public Guid UserId { get; set; }

        public RegisterConfirmationEventRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
