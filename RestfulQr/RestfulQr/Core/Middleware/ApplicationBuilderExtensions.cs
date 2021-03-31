using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using RestfulQr.Core.Auth;
using System;

namespace RestfulQr.Core.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use middleware to extract the qr code options from each request
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseQrCodeOptionsExtraction(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<QrCodeOptionsExtractionMiddleware>();
        }

        /// <summary>
        /// Configures authentication use use the <see cref="ApiKeyAuthenticationHandler"/> to authorize
        /// requests.
        /// </summary>
        /// <param name="authenticationBuilder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddApiKeySupport(this AuthenticationBuilder authenticationBuilder, Action<ApiKeyAuthenticationOptions> options)
        {
            return authenticationBuilder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, options);
        }
    }
}
