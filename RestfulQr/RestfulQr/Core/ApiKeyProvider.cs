using RestfulQr.Core.Auth;

namespace RestfulQr.Core
{
    /// <summary>
    /// Scoped class to faciliate easy api key extraction. This field is
    /// set during authorization via <see cref="ApiKeyAuthenticationHandler"/>
    /// </summary>
    public class ApiKeyProvider
    {
        /// <summary>
        /// The Api key that was provided. This will only be set to an api
        /// key that exists in the backing store
        /// </summary>
        public string ApiKey { get; set; }
    }
}
