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

        private readonly IGetRegisterInfoUseCase _getRegisterInfoUseCase;
        private readonly GetRegisterInfoPresenter _getRegisterInfoPresenter;


        public EventController(IRegisterUserInEventUseCase registerUserInEventUseCase,
                              RegisterUserInEventPresenter registerUserInEventPresenter,
                              IRegisterConfirmationInEventUseCase registerConfirmationInEventUseCase,
                              RegisterConfirmationPresenter registerConfirmationPresenter,
                              IGetRegisterInfoUseCase getRegisterInfoUseCase,
                              GetRegisterInfoPresenter getRegisterInfoPresenter)
        {
            _registerUserInEventUseCase = registerUserInEventUseCase;
            _registerUserInEventPresenter = registerUserInEventPresenter;
            _registerConfirmationInEventUseCase = registerConfirmationInEventUseCase;
            _registerConfirmationPresenter = registerConfirmationPresenter;
            _getRegisterInfoUseCase = getRegisterInfoUseCase;
            _getRegisterInfoPresenter = getRegisterInfoPresenter;
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

        [HttpGet("[action]/{registerId}")]
        [ProducesResponseType(typeof(GetRegisterInfoResponse), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetRegisterInfor(Guid registerId)
        {
            if (!ModelState.IsValid)
            { //re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _getRegisterInfoUseCase.HandleAsync(new Core.Dto.GetRegisterInfoRequest(registerId), _getRegisterInfoPresenter);

            return _getRegisterInfoPresenter.ContentResult;

        }
    }
}