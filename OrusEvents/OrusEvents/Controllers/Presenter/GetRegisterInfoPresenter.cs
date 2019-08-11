using Newtonsoft.Json;
using OrusEvents.Core.Dto;
using OrusEvents.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrusEvents.Controllers.Presenter
{
    public class GetRegisterInfoPresenter : IOutputPort<GetRegisterInfoResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetRegisterInfoPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetRegisterInfoResponse response)
        {
            if (response.Success && string.IsNullOrEmpty(response.Message))
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
            }
            else if (response.Errors != null && response.Errors.Any())
            {
                ContentResult.StatusCode = (int)HttpStatusCode.BadRequest;
                ContentResult.Content = response.Message;
            }

            ContentResult.Content = JsonConvert.SerializeObject(response, Formatting.Indented);
        }
    }
}
