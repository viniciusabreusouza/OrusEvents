using OrusEvents.Core.Dto;
using OrusEvents.Core.Interfaces;
using OrusEvents.Core.Interfaces.Repositories;
using OrusEvents.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.UseCases
{
    public class RegisterConfirmationInEventUseCase : IRegisterConfirmationInEventUseCase
    {
        private readonly IEventsRepository _eventRepository;

        public RegisterConfirmationInEventUseCase(IEventsRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> HandleAsync(RegisterConfirmationEventRequest message, IOutputPort<RegisterConfirmationEventResponse> outputPort)
        {
            var response = await _eventRepository.PostConfirmationEvent(message);

            outputPort.Handle(response.Success ? new RegisterConfirmationEventResponse(response.Confirmation, true) :
                                                 new RegisterConfirmationEventResponse(response.Errors, false, response.Message));
            return response.Success;
        }
    }
}
