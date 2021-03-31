using RestfulQr.Entities;
using RestfulQr.ViewModels;
using System.Threading.Tasks;

namespace RestfulQr.Services
{
    /// <summary>
    /// Describes functionality for creating api keys
    /// </summary>
    public interface IApiKeyService
    {
        /// <summary>
        /// Checks if a matching api key exists in the backing
        /// database.
        /// </summary>
        /// <param name="apiKey">Api key to check</param>
        /// <returns></returns>
        public Task<bool> ApiKeyExistsAsync(string apiKey);

        /// <summary>
        /// Creates an api key. An api consists of two parts joined by a period <br />
        ///     1. A cryptographically secure random 32 character string <br />
        ///     2. A unique generated GUID with the dashes removed
        /// </summary>
        /// <returns></returns>
        public Task<CreateApiKeyResult> CreateApiKeyAsync();

        /// <summary>
        /// Gets an api key.
        /// </summary>
        /// <param name="apiKey">Api key to get</param>
        /// <returns></returns>
        public Task<ApiKey> GetApiKeyAsync(string apiKey);

        /// <summary>
        /// Deletes an api key from the backing database.
        /// </summary>
        /// <param name="apiKey">Api key to delete</param>
        /// <returns></returns>
        public Task DeleteApiKeyAsync(string apiKey);
    }
}
