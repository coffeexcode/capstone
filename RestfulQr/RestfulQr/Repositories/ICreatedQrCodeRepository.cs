using RestfulQr.Entities;
using System.Threading.Tasks;

namespace RestfulQr.Repositories
{
    /// <summary>
    /// Describes functionality for saving qr codes in a database.
    /// Used for controlling access to qr codes via api keys.
    /// <see cref="ApiKey"/>
    /// </summary>
    public interface ICreatedQrCodeRepository
    {
        /// <summary>
        /// Gets a created qr code entity from the filename
        /// </summary>
        /// <param name="filename">The filename to search for</param>
        /// <returns>
        /// The CreatedQrCode entity if it exists, otherwise null
        /// </returns>
        public Task<CreatedQrCode> GetCreatedQrCodeByFilenameAsync(string filename);

        /// <summary>
        /// Checks whether a given api key has to the given file
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="filename">The name of the file</param>
        /// <returns>
        /// True if the file was created by the provided api key, otherwise false
        /// </returns>
        public Task<bool> CanAccessFileAsync(string apiKey, string filename);

        /// <summary>
        /// Creates a new entry for a created qr code
        /// </summary>
        /// <param name="created">The newly created qr code</param>
        /// <returns>
        /// The entity that was saved in the database. If the entity is null, it was not saved
        /// </returns>
        public Task<CreatedQrCode> CreateQrCodeAsync(CreatedQrCode created);

        /// <summary>
        /// Deletes a created qr code entity from the backing store.
        /// </summary>
        /// <param name="filename">The filename to delete</param>
        /// <returns></returns>
        public Task DeleteQrCodeAsync(string filename);

        /// <summary>
        /// Propagates any changes in an in memory cache to the backing store.
        /// </summary>
        /// <returns>
        /// The number of updated entities
        /// </returns>
        public Task<int> SaveChangesAsync();
    }
}
