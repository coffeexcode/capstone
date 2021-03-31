using RestfulQr.ViewModels;
using System.Threading.Tasks;

namespace RestfulQr.Services
{
    /// <summary>
    /// Describes functionality for creating qr codes
    /// </summary>
    public interface IQrCodeService
    {
        /// <summary>
        /// Creates a qr code by encoding a json string
        /// </summary>
        /// <param name="jsonContent">JSON string to encode</param>
        /// <returns></returns>
        public Task<CreateQrCodeResult> CreateJsonQrCodeAsync(string jsonContent);

        /// <summary>
        /// Deletes a qr code. Will delete both a file on the filesystem, and the 
        /// entry in the backing store. 
        /// 
        /// Assumes that the request has already been authorized.
        /// </summary>
        /// <param name="filename">The file to delete. </param>
        /// <returns>
        /// True if the delete was successful
        /// </returns>
        public Task DeleteAsync(string filename);

    }
}
