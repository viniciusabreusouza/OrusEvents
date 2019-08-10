using OrusEvents.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Interfaces.Repositories
{
    public interface IEventsRepository
    {
        Task<RegisterUserEventResponse> PostRegisterUserEvent(RegisterUserEventRequest registerUserEventRequest);
        Task<RegisterConfirmationEventResponse> PostConfirmationEvent(RegisterConfirmationEventRequest registerUserEventRequest);
    }
}
