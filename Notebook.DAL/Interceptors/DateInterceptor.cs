﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Notebook.Domain.Interfaces;

namespace Notebook.DAL.Interceptors
{
    public class DateInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var dbContext = eventData.Context;
            if (dbContext == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var entries = dbContext.ChangeTracker.Entries<IAuditable>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var dbContext = eventData.Context;
            if (dbContext == null)
            {
                return base.SavingChanges(eventData, result);
            }

            var entries = dbContext.ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SavingChanges(eventData, result);
        }
    }
}