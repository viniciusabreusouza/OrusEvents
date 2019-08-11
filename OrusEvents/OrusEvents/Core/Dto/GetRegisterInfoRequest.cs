using OrusEvents.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class GetRegisterInfoRequest : IUseCaseRequest<GetRegisterInfoResponse>
    {
        public Guid RegisterId { get; set; }

        public GetRegisterInfoRequest(Guid register)
        {
            RegisterId = register;
        }
    }
}
