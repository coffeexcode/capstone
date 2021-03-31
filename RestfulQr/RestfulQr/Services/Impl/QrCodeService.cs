using RestfulQr.Core;
using RestfulQr.Entities;
using RestfulQr.Repositories;
using RestfulQr.ViewModels;
using System;
using System.Threading.Tasks;

namespace RestfulQr.Services.Impl
{
    public class QrCodeService : IQrCodeService
    {
        private readonly IQrCodeDataService qrCodeDataService;
        private readonly IQrCodeRenderingService qrCodeRenderingService;
        private readonly IImageFileService imageFileService;
        private readonly ICreatedQrCodeRepository qrCodeRepository;
        private readonly ApiKeyProvider apiKeyProvider;

        public QrCodeService(
            IQrCodeDataService qrCodeDataService,
            IQrCodeRenderingService qrCodeRenderingService,
            IImageFileService imageFileService,
            ICreatedQrCodeRepository qrCodeRepository,
            ApiKeyProvider apiKeyProvider
            )
        {
            this.qrCodeDataService = qrCodeDataService;
            this.qrCodeRenderingService = qrCodeRenderingService;
            this.imageFileService = imageFileService;
            this.qrCodeRepository = qrCodeRepository;
            this.apiKeyProvider = apiKeyProvider;
        }

        public async Task<CreateQrCodeResult> CreateJsonQrCodeAsync(string jsonContent)
        {
            // Create the data
            var data = await qrCodeDataService.GenerateJsonQrCodeDataAsync(jsonContent);

            // Create the image
            var bmp = await qrCodeRenderingService.RenderQrCodeAsBitmapAsync(data);

            // Create a name for the file
            var file = $"{Guid.NewGuid()}.png";

            // Save the file to the system
            await imageFileService.WriteImageFileAsync(file, bmp, qrCodeRenderingService.GetImageCodecInfo(), qrCodeRenderingService.GetEncoderParameters());

            // Add to the database to control access
            var created = new CreatedQrCode
            {
                Created = DateTime.Now,
                Filename = file,
                CreatedBy = apiKeyProvider.ApiKey
            };

            var result = await qrCodeRepository.CreateQrCodeAsync(created);

            await qrCodeRepository.SaveChangesAsync();

            return result == null
                ? CreateQrCodeResult.Failed("Unable to save result")
                : CreateQrCodeResult.Success(result);
        }

        public async Task DeleteAsync(string filename)
        {
            try
            {
                // Delete from filesystem
                await imageFileService.DeleteImageFileAsync(filename);

                // Delete from the backing store
                await qrCodeRepository.DeleteQrCodeAsync(filename);
                await qrCodeRepository.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error deleting qr code");
            }

        }
    }
}
