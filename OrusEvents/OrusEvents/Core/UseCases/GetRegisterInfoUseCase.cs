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
    public class GetRegisterInfoUseCase : IGetRegisterInfoUseCase
    {
        private readonly IEventsRepository _eventRepository;

        public GetRegisterInfoUseCase(IEventsRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> HandleAsync(GetRegisterInfoRequest message, IOutputPort<GetRegisterInfoResponse> outputPort)
        {
            var response = await _eventRepository.GetRegisterInformation(message);

            outputPort.Handle(response.Success ? new GetRegisterInfoResponse(response.EventId, response.EventName, response.EventDate, response.Payed, response.UserEmail, true, response.Message) :
                                                 new GetRegisterInfoResponse(response.Errors, false, response.Message));
            return response.Success;
        }
    }
}
