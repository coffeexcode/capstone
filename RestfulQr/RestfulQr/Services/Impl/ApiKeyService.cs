using RestfulQr.Entities;
using RestfulQr.Repositories;
using RestfulQr.ViewModels;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RestfulQr.Services.Impl
{
    /// <summary>
    /// Implements api key service functionality using a repository
    /// Note: Any function called in this class is assumed to be authorized
    /// </summary>
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiKeyRepository repository;

        public ApiKeyService(
            IApiKeyRepository repository
            )
        {
            this.repository = repository;
        }

        public async Task<bool> ApiKeyExistsAsync(string apiKey)
        {
            return await GetApiKeyAsync(apiKey) != null;
        }

        public async Task<CreateApiKeyResult> CreateApiKeyAsync()
        {
            var prefix = CreatePrefix();
            var body = CreateBody();
            var apiKey = string.Join(".", prefix, body);

            var result = await repository.CreateApiKeyAsync(apiKey);

            if (result == null)
            {
                return CreateApiKeyResult.Failed("Unable to save API key");
            }

            await repository.SaveChangesAsync();

            return CreateApiKeyResult.Success(result);
        }

        public async Task DeleteApiKeyAsync(string apiKey)
        {
            if (!await ApiKeyExistsAsync(apiKey))
            {
                return;
            }

            await repository.DeleteApiKeyAsync(apiKey);
            await repository.SaveChangesAsync();
        }

        public async Task<ApiKey> GetApiKeyAsync(string apiKey)
        {
            return await repository.GetApiKeyAsync(apiKey);
        }

        private static string CreatePrefix()
        {
            var bytes = new byte[8];

            using var random = RandomNumberGenerator.Create();
            random.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        private static string CreateBody()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
