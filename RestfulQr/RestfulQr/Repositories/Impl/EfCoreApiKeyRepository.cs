using Microsoft.EntityFrameworkCore;
using RestfulQr.Entities;
using System;
using System.Threading.Tasks;

namespace RestfulQr.Repositories.Impl
{
    /// <summary>
    /// Implements <see cref="IApiKeyRepository"/> by using Entity framework core
    /// </summary>
    public class EfCoreApiKeyRepository : IApiKeyRepository
    {
        private readonly RestfulQrDbContext context;

        public EfCoreApiKeyRepository(
            RestfulQrDbContext context
        )
        {
            this.context = context;
        }

        public async Task<ApiKey> CreateApiKeyAsync(string key)
        {
            var saved = await context.ApiKeys.AddAsync(new ApiKey
            {
                Key = key,
                DateCreated = DateTime.Now
            });

            return saved.Entity;
        }

        public async Task DeleteApiKeyAsync(string key)
        {
            var toDelete = await context.ApiKeys.FirstOrDefaultAsync(e => e.Key == key);

            if (toDelete == null)
            {
                return;
            }

            context.ApiKeys.Remove(toDelete);
        }

        public async Task<ApiKey> GetApiKeyAsync(string key)
        {
            return await context.ApiKeys.AsNoTracking().FirstOrDefaultAsync(e => e.Key == key);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
