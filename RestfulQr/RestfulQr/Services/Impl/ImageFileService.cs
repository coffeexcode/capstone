using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RestfulQr.ViewModels;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace RestfulQr.Services.Impl
{
    public class ImageFileService : IImageFileService
    {
        private readonly string fileSystemPath;

        private readonly string relativePath;

        public ImageFileService(
            IConfiguration config,
            IWebHostEnvironment environment
        )
        {
            if (string.IsNullOrEmpty(config.GetSection("Images")["Path"]))
            {
                throw new Exception("Cannot get base path from appSettings.json. Ensure that a path is set");
            }

            relativePath = config.GetSection("Images")["Path"];
            fileSystemPath = Path.Combine(environment.ContentRootPath, relativePath);
        }

        public async Task DeleteImageFileAsync(string filename)
        {
            EnsureExists(filename);

            await Task.Run(() => File.Delete(Path.Combine(fileSystemPath, filename)));
        }

        public void EnsureExists(string filename)
        {
            if (!File.Exists(Path.Combine(fileSystemPath, filename)))
            {
                throw new FileNotFoundException(Path.Combine(fileSystemPath, filename));
            }
        }

        public async Task<byte[]> GetFileAsBytesAsync(string filename)
        {
            EnsureExists(filename);

            return await Task.Run(() =>
            {
                using var fileStream = new FileStream(Path.Combine(fileSystemPath, filename), FileMode.Open, FileAccess.Read, FileShare.None);

                var buffer = new byte[fileStream.Length];

                fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));

                return buffer;
            });
        }

        public async Task<CreateFileResult> WriteImageFileAsync(string file, Bitmap bmp, ImageCodecInfo codec, EncoderParameters encoderParameters)
        {
            try
            {
                await Task.Run(() => bmp.Save(Path.Combine(fileSystemPath, file), codec, encoderParameters));

                return CreateFileResult.Success(file);
            }
            catch (Exception e)
            {
                return CreateFileResult.Failed(e.Message);
            }
        }

        public string GetImagePath() => relativePath;
    }
}
