using System.Collections.Generic;

namespace RestfulQr.ViewModels
{
    /// <summary>
    /// Result of creating an file
    /// </summary>
    public class CreateFileResult
    {
        private CreateFileResult() { }

        /// <summary>
        /// Whether the operation was successful
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Any errors that occured during the operation
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// The name of the created file
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Creates an object representing a successfull file creation,
        /// </summary>
        /// <param name="filename">The name of the file that was created.</param>
        /// <returns></returns>
        public static CreateFileResult Success(string filename)
        {
            return new CreateFileResult
            {
                Succeeded = true,
                Filename = filename
            };
        }

        /// <summary>
        /// Creates an object representing a failure to create a file.
        /// </summary>
        /// <param name="message">
        /// The message that caused the failure. This is usually the exception
        /// that occured.
        /// </param>
        /// <returns></returns>
        public static CreateFileResult Failed(string message)
        {
            return new CreateFileResult
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
