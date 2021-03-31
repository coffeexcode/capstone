using RestfulQr.Entities;
using System.Collections.Generic;

namespace RestfulQr.ViewModels
{
    /// <summary>
    /// Result of creating an api key
    /// </summary>
    public class CreateApiKeyResult
    {
        private CreateApiKeyResult() { }

        /// <summary>
        /// Whether the operation was successful
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Any errors that occured during the operation
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// The api key entity that was created
        /// <see cref="ApiKey"/>
        /// </summary>
        public ApiKey ApiKey { get; set; }

        /// <summary>
        /// Creates a successfully created api key object.
        /// </summary>
        /// <param name="apiKey">The api key that was created</param>
        /// <returns></returns>
        public static CreateApiKeyResult Success(ApiKey apiKey)
        {
            return new CreateApiKeyResult
            {
                Succeeded = true,
                ApiKey = apiKey
            };
        }

        /// <summary>
        /// Creates a failed to create an api key object.
        /// </summary>
        /// <param name="message">
        /// The error message that caused the failure. This should
        /// usually be the exception that occured.
        /// </param>
        /// <returns></returns>
        public static CreateApiKeyResult Failed(string message)
        {
            return new CreateApiKeyResult
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
