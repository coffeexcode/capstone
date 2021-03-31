using System;

namespace RestfulQr.Entities
{
    /// <summary>
    /// Represents an api key that is required by users to create and retrieve qr codes
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// The generated api key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The date the api key was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The last datetime that the api key was successfully used
        /// </summary>
        public DateTime LastUsed { get; set; }
    }
}
