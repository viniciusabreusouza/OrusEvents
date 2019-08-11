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
    public class RegisterConfirmationPresenter : IOutputPort<RegisterConfirmationEventResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterConfirmationPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterConfirmationEventResponse response)
        {
            if (response.Success && string.IsNullOrEmpty(response.Message))
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
            }
            else if (!string.IsNullOrEmpty(response.Message) && response.Message == "Usuário já confirmado no evento.")
            {
                ContentResult.StatusCode = (int)HttpStatusCode.Conflict;
                ContentResult.Content = response.Message;
            }
            else if (!string.IsNullOrEmpty(response.Message) && response.Message == "Usuário não está cadastrado no evento.")
            {
                ContentResult.StatusCode = (int)HttpStatusCode.NoContent;
                ContentResult.Content = response.Message;
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
