using System.Threading.Tasks;
using Notebook.Domain.Dto.Role;
using Notebook.Domain.Dto.UserRole;
using Notebook.Domain.Entity;
using Notebook.Domain.Interfaces.Repositories;
using Notebook.Domain.Result;

namespace Notebook.Domain.Interfaces.Services
{
    public interface IRoleService
    {
        Task<BaseResult<RoleDto>> CreateRoleAsync(CreateRoleDto dto);
        
        Task<BaseResult<RoleDto>> DeleteRoleAsync(long id);
        
        Task<BaseResult<RoleDto>> UpdateRoleAsync(RoleDto dto);
        
        Task<BaseResult<UserRoleDto>> AddRoleForUserAsync(UserRoleDto dto);
        
        Task<BaseResult<UserRoleDto>> DeleteRoleForUserAsync(DeleteUserRoleDto dto);
        
        Task<BaseResult<UserRoleDto>> UpdateRoleForUserAsync(UpdateUserRoleDto dto);
    }
}