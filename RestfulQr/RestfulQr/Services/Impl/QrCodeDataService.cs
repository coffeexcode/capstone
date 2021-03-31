using QRCoder;
using RestfulQr.Core;
using System.Threading.Tasks;

namespace RestfulQr.Services.Impl
{
    public class QrCodeDataService : IQrCodeDataService
    {
        private readonly QRCodeGenerator generator;
        private readonly QrCodeOptions options;

        public QrCodeDataService(
            QrCodeOptions options)
        {
            generator = new QRCodeGenerator();
            this.options = options;
        }

        public async Task<QRCodeData> GenerateJsonQrCodeDataAsync(string jsonContent)
        {
            return await Task.Run(() => generator.CreateQrCode(jsonContent, options.ECCLevel));
        }
    }
}
