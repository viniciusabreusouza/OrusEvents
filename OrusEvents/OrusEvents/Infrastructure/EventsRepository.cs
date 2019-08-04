using Microsoft.Extensions.Configuration;
using OrusEvents.Core.Dto;
using OrusEvents.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Infrastructure
{
    public class EventsRepository : IEventsRepository
    {
        private EventsContext DbContext { get; }

        public EventsRepository(IConfiguration configuration)
        {
            DbContext = new EventsContext(configuration);
        }

        public async Task<RegisterUserEventResponse> PostRegisterUserEvent(RegisterUserEventRequest registerUserEventRequest)
        {
            Task<RegisterUserEventResponse> registerResponse = null;

            try
            {
                //Validar Evento no RDStation

                var currentEvent = DbContext.Events.FirstOrDefault(x => x.Id == registerUserEventRequest.Id);

                if (currentEvent != null && currentEvent.Id > 0)
                {
                    //var userId = DbContext
                }

                return await registerResponse;
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                return new RegisterUserEventResponse(errors, false, null); ;
            }
            finally
            {

            }
        }
    }
}
