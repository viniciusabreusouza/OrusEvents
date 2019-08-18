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
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IEventsRepository _eventRepository;

        public LoginUseCase(IEventsRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> HandleAsync(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            var response = await _eventRepository.LoginUser(message);

            outputPort.Handle(response.Success ? new LoginResponse(response.UserId, true, response.Message) :
                                                 new LoginResponse(response.Errors, false, response.Message));
            return response.Success;
        }
    }
}
