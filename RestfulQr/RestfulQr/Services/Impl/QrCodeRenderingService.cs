using QRCoder;
using RestfulQr.Core;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulQr.Services.Impl
{
    public class QrCodeRenderingService : IQrCodeRenderingService
    {
        private readonly QrCodeOptions options;

        public QrCodeRenderingService(
            QrCodeOptions options)
        {
            this.options = options;
        }

        public EncoderParameters GetEncoderParameters()
        {
            var encoderParams = new EncoderParameters(2);

            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, options.Quality);
            encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, options.Compression);

            return encoderParams;
        }

        public string GetExtension()
        {
            return "png";
        }

        public ImageCodecInfo GetImageCodecInfo()
        {
            var mime = ImageUtil.GetMimeTypeByExtension(GetExtension());

            var codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(e => e.MimeType == mime);

            if (codec == null)
            {
                throw new NotSupportedException($"Cannot find codec for '{mime}'");
            }

            return codec;
        }

        public async Task<Bitmap> RenderQrCodeAsBitmapAsync(QRCodeData data)
        {
            return await Task.Run(() => new QRCode(data).GetGraphic(options.PixelsPerModule, options.Dark, options.Light, options.DrawQuietZones));
        }
    }
}
