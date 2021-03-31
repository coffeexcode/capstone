using System.Threading.Tasks;

namespace RestfulQr.Services
{
    /// <summary>
    /// Describes functionality for controlling access to protected operations
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Checks if a given api key has access to a given file.
        /// If this returns true, operations can safely be performed on
        /// the saved image and database.
        /// </summary>
        /// <param name="apiKey">The provided api key</param>
        /// <param name="file">The name of the file to access</param>
        /// <returns>
        /// True if the file was created by the api key, otherwise false.
        /// </returns>
        public Task<bool> CanAccessAsync(string apiKey, string file);
    }
}
