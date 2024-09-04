using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Notebook.Domain.Dto;
using Notebook.Domain.Result;

namespace Notebook.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
        
        Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
    }
}