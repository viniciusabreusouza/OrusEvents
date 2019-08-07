using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrusEvents.Controllers.Models;
using OrusEvents.Controllers.Presenter;
using OrusEvents.Core.Interfaces.UseCases;

namespace OrusEvents.Controllers
{
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IRegisterUserInEventUseCase _registerUserInEventUseCase;
        private readonly RegisterUserInEventPresenter _registerUserInEventPresenter;

        public EventController(IRegisterUserInEventUseCase registerUserInEventUseCase,
                              RegisterUserInEventPresenter registerUserInEventPresenter)
        {
            _registerUserInEventUseCase = registerUserInEventUseCase;
            _registerUserInEventPresenter = registerUserInEventPresenter;
        }

        [HttpGet("[action]/{id}/{email}")]
        [ProducesResponseType(typeof(RegisterUserEventResponse), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> RegisterUserInEvent(int id, string email)
        {
            if (!ModelState.IsValid)
            { //re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _registerUserInEventUseCase.HandleAsync(new Core.Dto.RegisterUserEventRequest(id, email), _registerUserInEventPresenter);

            return _registerUserInEventPresenter.ContentResult;

        }
    }
}