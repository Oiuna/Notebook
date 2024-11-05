using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Notebook.Domain.Entity;
using Notebook.Domain.Interfaces.Databases;
using Notebook.Domain.Interfaces.Repositories;

namespace Notebook.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IBaseRepository<User> users, IBaseRepository<Role> roles, IBaseRepository<UserRole> userRoles)
        {
            _context = context;
            Users = users;
            Roles = roles;
            UserRoles = userRoles;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IBaseRepository<User> Users { get; set; }
        public IBaseRepository<Role> Roles { get; set; }
        
        public IBaseRepository<UserRole> UserRoles { get; set; }
    }
}