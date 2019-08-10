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

        private readonly IRegisterConfirmationInEventUseCase _registerConfirmationInEventUseCase;
        private readonly RegisterConfirmationPresenter _registerConfirmationPresenter;


        public EventController(IRegisterUserInEventUseCase registerUserInEventUseCase,
                              RegisterUserInEventPresenter registerUserInEventPresenter,
                              IRegisterConfirmationInEventUseCase registerConfirmationInEventUseCase,
                              RegisterConfirmationPresenter registerConfirmationPresenter)
        {
            _registerUserInEventUseCase = registerUserInEventUseCase;
            _registerUserInEventPresenter = registerUserInEventPresenter;
            _registerConfirmationInEventUseCase = registerConfirmationInEventUseCase;
            _registerConfirmationPresenter = registerConfirmationPresenter;
        }

        [HttpPost("[action]/{id}/{email}")]
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

        [HttpPost("[action]/{userId}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> RegisterConfirmationInEvent(Guid userId)
        {
            if (!ModelState.IsValid)
            { //re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _registerConfirmationInEventUseCase.HandleAsync(new Core.Dto.RegisterConfirmationEventRequest(userId), _registerConfirmationPresenter);

            return _registerConfirmationPresenter.ContentResult;

        }
    }
}