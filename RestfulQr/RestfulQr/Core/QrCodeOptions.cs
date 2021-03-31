using RestfulQr.Core.Middleware;
using static QRCoder.QRCodeGenerator;

namespace RestfulQr.Core
{
    /// <summary>
    /// Qr code options that are available to set via query parameters.
    /// <see cref="QrCodeOptionsExtractionMiddleware"/>
    /// </summary>
    public class QrCodeOptions
    {
        public ECCLevel ECCLevel { get; set; }

        public int PixelsPerModule { get; set; }

        public string Dark { get; set; }

        public string Light { get; set; }

        public bool DrawQuietZones { get; set; }

        public byte Compression { get; set; }

        public byte Quality { get; set; }
    }
}
