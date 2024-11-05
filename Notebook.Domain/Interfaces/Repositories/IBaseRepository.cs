using System.Linq;
using System.Threading.Tasks;
using Notebook.Domain.Interfaces.Databases;

namespace Notebook.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IStateSaveChanges
    {
        IQueryable<TEntity> GetAll();
        

        Task<TEntity> CreateAsync(TEntity entity);
        
        TEntity Update(TEntity entity);
        
        void Remove(TEntity entity);
    }
}