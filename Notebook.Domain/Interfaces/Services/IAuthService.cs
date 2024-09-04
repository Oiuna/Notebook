using System.Threading.Tasks;
using Notebook.Domain.Dto;
using Notebook.Domain.Dto.User;
using Notebook.Domain.Result;

namespace Notebook.Domain.Interfaces.Services
{
    /// <summary>
    /// Сервис, предназначенный для авторизации и регистрации
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<UserDto>> Register(RegisterUserDto dto);
        
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<TokenDto>> Login(LoginUserDto dto);
    }
}