using OrusEvents.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Interfaces.UseCases
{
    public interface IRegisterUserInEventUseCase : IUseCaseRequestHandler<RegisterUserEventRequest, RegisterUserEventResponse>
    {
    }
}
