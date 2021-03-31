using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Data
{
    /// <summary>
    /// Injectable context into services in order to provide clean access
    /// to saving changes currently tracked by the context.
    /// 
    /// <see cref="EventManagementDbContext"/>
    /// </summary>
    /// <typeparam name="T">The concrete context to provide.</typeparam>
    public interface IDbContextProvider<T> where T : DbContext
    {
        public T GetContext();

        public Task<int> SaveChangesAsync();
    }

    /// <summary>
    /// Custom base EF core db context to provide helper methods to reduce
    /// code for saving and accessing the context in service classes.
    /// </summary>
    public class EfCoreDbContext : IDbContextProvider<EventManagementDbContext>
    {
        private readonly EventManagementDbContext context;

        public EfCoreDbContext(
            EventManagementDbContext context
            )
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the current db context.
        /// </summary>
        /// <returns></returns>
        public EventManagementDbContext GetContext()
        {
            return context;
        }

        /// <summary>
        /// Saves any changes tracked by the context.
        /// </summary>
        /// <returns>The number of entities changed by the save operation.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
