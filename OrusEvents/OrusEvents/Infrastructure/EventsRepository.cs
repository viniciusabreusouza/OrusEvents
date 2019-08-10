using Microsoft.EntityFrameworkCore;
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
                //Validar Evento no RDStation e como buscar o evento

                var currentEvent = DbContext.Events.FirstOrDefault(x => x.Id == registerUserEventRequest.Id);

                if (currentEvent != null && currentEvent.Id > 0)
                {
                    var user = DbContext.Users.FirstOrDefault(x => x.Email.ToLower() == registerUserEventRequest.Email.ToLower());

                    if (user == null)
                    {
                        //Cria usuário
                        user = DbContext.Users.Add(new Entities.Users
                        {
                            Email = registerUserEventRequest.Email.ToLower(),
                            Name = null,
                            Phone = null,
                            Id = Guid.NewGuid()
                        }).Entity;

                        await DbContext.SaveChangesAsync();
                    }

                    var idRegister = await DbContext.Registers.AddAsync(new Entities.Registers
                    {
                        Event = currentEvent,
                        EventId = currentEvent.Id,
                        User = user,
                        UserId = user.Id,
                        Id = Guid.NewGuid()
                    });

                    await DbContext.SaveChangesAsync();

                    registerResponse = Task.FromResult(new RegisterUserEventResponse(idRegister.Entity.Id, true));
                }
                else
                {
                    registerResponse = Task.FromResult(new RegisterUserEventResponse(null, false, "Não existe evento cadastrado."));
                }

                return await registerResponse;
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                return new RegisterUserEventResponse(errors, false, null); ;
            }
        }

        public async Task<RegisterConfirmationEventResponse> PostConfirmationEvent(RegisterConfirmationEventRequest registerUserEventRequest)
        {
            Task<RegisterConfirmationEventResponse> registerConfirmation = null;

            try
            {
                var userInEvent = DbContext.Registers.Include(x => x.Event).FirstOrDefault(x => x.Id == registerUserEventRequest.UserId);

                if (userInEvent != null)
                {
                    if (DateTime.Now > userInEvent.Event.Date)
                    {
                        registerConfirmation = Task.FromResult(new RegisterConfirmationEventResponse(false, false, "Data do evento expirada."));
                        userInEvent.Confirmed = false;
                        return await registerConfirmation;
                    }

                    if (userInEvent.Confirmed)
                    {
                        registerConfirmation = Task.FromResult(new RegisterConfirmationEventResponse(false, false, "Usuário já confirmado no evento."));
                        return await registerConfirmation;
                    }

                    userInEvent.Confirmed = true;

                    await DbContext.SaveChangesAsync();
                    registerConfirmation = Task.FromResult(new RegisterConfirmationEventResponse(true, true));
                }
                else
                {
                    registerConfirmation = Task.FromResult(new RegisterConfirmationEventResponse(false, false, "Usuário não está cadastrado no evento."));
                }

                return await registerConfirmation;
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                return new RegisterConfirmationEventResponse(errors, false, null); ;
            }
        }
    }
}
