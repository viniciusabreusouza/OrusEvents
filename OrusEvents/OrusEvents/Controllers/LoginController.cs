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
    public class LoginController :  ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public LoginController(ILoginUseCase loginUseCase,
                               LoginPresenter loginPresenter)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;          
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Login(string user, string password)
        {
            if (!ModelState.IsValid)
            { //re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _loginUseCase.HandleAsync(new Core.Dto.LoginRequest(user, password), _loginPresenter);

            return _loginPresenter.ContentResult;

        }
    }
}