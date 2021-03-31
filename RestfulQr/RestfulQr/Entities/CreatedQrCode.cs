using System;

namespace RestfulQr.Entities
{
    /// <summary>
    /// Represented a qr code that was generated.
    /// Filename is the actual filename on disk
    /// </summary>
    public class CreatedQrCode
    {
        /// <summary>
        /// The name of this file (including extension)
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The date this qr code was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The api key that was used to created this qr code
        /// <see cref="ApiKey"/>
        /// </summary>
        public string CreatedBy { get; set; }
    }
}
