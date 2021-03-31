using RestfulQr.Entities;
using System.Threading.Tasks;

namespace RestfulQr.Repositories
{
    /// <summary>
    /// Describes functionality for CRUD operations for api keys.
    /// </summary>
    public interface IApiKeyRepository
    {
        /// <summary>
        /// Retrieve an api key from the backing data store
        /// </summary>
        /// <param name="key">The key to retrieve</param>
        /// <returns></returns>
        public Task<ApiKey> GetApiKeyAsync(string key);

        /// <summary>
        /// Create an api key in the backing store.
        /// </summary>
        /// <param name="key">The key to create</param>
        /// <returns></returns>
        public Task<ApiKey> CreateApiKeyAsync(string key);

        /// <summary>
        /// Delete an api key from the backing store.
        /// </summary>
        /// <param name="key">The key to delete</param>
        /// <returns></returns>
        public Task DeleteApiKeyAsync(string key);

        /// <summary>
        /// Save any changes from a memory cache to backing store
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }
}
