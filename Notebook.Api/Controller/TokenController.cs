using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notebook.Domain.Dto;
using Notebook.Domain.Interfaces.Services;
using Notebook.Domain.Result;

namespace Notebook.Api.Controller
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<BaseResult<TokenDto>>> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var response = await _tokenService.RefreshToken(tokenDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}