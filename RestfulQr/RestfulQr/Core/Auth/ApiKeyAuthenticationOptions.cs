using Microsoft.AspNetCore.Authentication;

namespace RestfulQr.Core.Auth
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "ApiKey";

        public string Scheme => DefaultScheme;

        public string AuthenticationType = DefaultScheme;
    }
}