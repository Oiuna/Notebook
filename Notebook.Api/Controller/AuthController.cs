using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notebook.Domain.Dto;
using Notebook.Domain.Dto.User;
using Notebook.Domain.Interfaces.Services;
using Notebook.Domain.Result;

namespace Notebook.Api.Controller
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        ///Регистрация пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<BaseResult<UserDto>>> Register([FromBody]RegisterUserDto dto)
        {
            var response = await _authService.Register(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        
        /// <summary>
        /// Логин пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<BaseResult<TokenDto>>> Login([FromBody] LoginUserDto dto)
        {
            var response = await _authService.Login(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}