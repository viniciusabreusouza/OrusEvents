using Newtonsoft.Json;
using OrusEvents.Core.Dto;
using OrusEvents.Core.Interfaces;
using System;
using System.Net;

namespace OrusEvents.Controllers.Presenter
{
    public class RegisterUserInEventPresenter : IOutputPort<RegisterUserEventResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterUserInEventPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterUserEventResponse response)
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
