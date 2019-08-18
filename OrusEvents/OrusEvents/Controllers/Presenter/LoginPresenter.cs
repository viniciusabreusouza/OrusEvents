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
    public class LoginPresenter : IOutputPort<LoginResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LoginResponse response)
        {
            if (response.Success && string.IsNullOrEmpty(response.Message))
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                ContentResult.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            ContentResult.Content = JsonConvert.SerializeObject(response, Formatting.Indented);
        }
    }
}
