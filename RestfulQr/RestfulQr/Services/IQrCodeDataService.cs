using QRCoder;
using System.Threading.Tasks;

namespace RestfulQr.Services
{
    /// <summary>
    /// Describes functionality for creating QRCode data
    /// <see cref="QRCodeData"/>
    /// </summary>
    public interface IQrCodeDataService
    {
        /// <summary>
        /// Generates a qr code for a json object
        /// </summary>
        /// <param name="jsonContent">JSON string to encode</param>
        /// <returns></returns>
        public Task<QRCodeData> GenerateJsonQrCodeDataAsync(string jsonContent);
    }
}
