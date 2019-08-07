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
    public sealed class RegisterUserInEventUseCase : IRegisterUserInEventUseCase
    {
        private readonly IEventsRepository _eventRepository;

        public RegisterUserInEventUseCase(IEventsRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> HandleAsync(RegisterUserEventRequest message, IOutputPort<RegisterUserEventResponse> outputPort)
        {
            var response = await _eventRepository.PostRegisterUserEvent(message);

            outputPort.Handle(response.Success ? new RegisterUserEventResponse(response.IdRegister, true) :
                                                 new RegisterUserEventResponse(response.Errors, false, response.Message));
            return response.Success;
        }
    }
}
