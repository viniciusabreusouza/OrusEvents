using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Core.Dto
{
    public class BaseResponse
    {
            public bool Success { get; }
            public string Message { get; }

            public BaseResponse(bool success = false, string message = null)
            {
                Success = success;
                Message = message;
            }
    }
}
