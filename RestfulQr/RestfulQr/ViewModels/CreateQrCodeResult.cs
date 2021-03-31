using RestfulQr.Entities;
using System.Collections.Generic;

namespace RestfulQr.ViewModels
{
    /// <summary>
    /// Result of creating a qr code
    /// </summary>
    public class CreateQrCodeResult
    {
        private CreateQrCodeResult() { }

        /// <summary>
        /// Whether the operation was successful
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Any errors that occured during the operation
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// The created qr code entity that was created
        /// <see cref="CreatedQrCode"/>
        /// </summary>
        public CreatedQrCode CreatedQrCode { get; set; }

        /// <summary>
        /// The data that was encoded in the created qr code
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Creates an object that represents a successfully created qr code.
        /// </summary>
        /// <param name="qrCode">
        ///     The CreatedQrCode object that wass created.
        ///     <see cref="CreatedQrCode"/>
        /// </param>
        /// <returns></returns>
        public static CreateQrCodeResult Success(CreatedQrCode qrCode)
        {
            return new CreateQrCodeResult
            {
                Succeeded = true,
                CreatedQrCode = qrCode
            };
        }

        /// <summary>
        /// Creates an object that represents a failured to create a qr code.
        /// </summary>
        /// <param name="message">
        /// The error message that caused the failure. This is usually the exception that
        /// occured.
        /// </param>
        /// <returns></returns>
        public static CreateQrCodeResult Failed(string message)
        {
            return new CreateQrCodeResult
            {
                Succeeded = false,
                Errors = new List<string>
                {
                    message
                }
            };
        }
    }
}
