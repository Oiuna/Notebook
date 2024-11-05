using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Notebook.Domain.Entity;
using Notebook.Domain.Interfaces.Repositories;

namespace Notebook.Domain.Interfaces.Databases
{
    public interface IUnitOfWork : IStateSaveChanges
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        
        IBaseRepository<User> Users { get; set; }
        
        IBaseRepository<Role> Roles { get; set; }
        
        IBaseRepository<UserRole> UserRoles { get; set; }
    }
}