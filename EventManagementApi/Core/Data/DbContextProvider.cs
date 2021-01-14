using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Data
{
    public interface IDbContextProvider<T> where T : DbContext
    {
        public T GetContext();

        public Task<int> SaveChangesAsync();
    }

    public class EfCoreDbContext : IDbContextProvider<EventManagementDbContext>
    {
        private readonly EventManagementDbContext context;

        public EfCoreDbContext(
            EventManagementDbContext context
            )
        {
            this.context = context;
        }

        public EventManagementDbContext GetContext()
        {
            return context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
