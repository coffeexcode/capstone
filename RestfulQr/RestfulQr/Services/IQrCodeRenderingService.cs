using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace RestfulQr.Services
{
    /// <summary>
    /// Described functionality for rendering a qr code
    /// </summary>
    public interface IQrCodeRenderingService
    {
        /// <summary>
        /// Renders a qr code as a bitmap. 
        /// Can be used to render as .png or .jpg
        /// </summary>
        /// <param name="data">The qr code data to encode in the image</param>
        /// <returns>
        /// A bitmap of the encoded data
        /// </returns>
        public Task<Bitmap> RenderQrCodeAsBitmapAsync(QRCodeData data);

        /// <summary>
        /// Gets encoder parameters used to save the qr code as an
        /// image
        /// </summary>
        /// <returns></returns>
        public EncoderParameters GetEncoderParameters();

        /// <summary>
        /// Gets the image codec info used to save the qr code as an
        /// image file
        /// </summary>
        /// <returns></returns>
        public ImageCodecInfo GetImageCodecInfo();

        /// <summary>
        /// Gets the requested extension for the image file.
        /// </summary>
        /// <returns></returns>
        public string GetExtension();
    }
}
