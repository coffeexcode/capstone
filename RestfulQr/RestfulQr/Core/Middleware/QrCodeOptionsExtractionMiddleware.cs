using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static QRCoder.QRCodeGenerator;

namespace RestfulQr.Core.Middleware
{
    /// <summary>
    /// Middleware to extract qr codes from each api request
    /// </summary>
    public class QrCodeOptionsExtractionMiddleware
    {
        private readonly RequestDelegate next;

        private string DefaultEccLevel;

        private string DefaultLightColour;

        private string DefaultDarkColour;

        private bool DefaultDrawQuietZones;

        private byte DefaultCompression;

        private byte DefaultQuality;

        private int DefaultPixelsPerModule;


        public QrCodeOptionsExtractionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration config, QrCodeOptions qrCodeOptions)
        {
            // Set default options
            ConfigureDefaultOptions(config);

            // Overwrite default with any user provided options
            var configuredOptions = ConfigureOptions(context);

            qrCodeOptions.ECCLevel = configuredOptions.ECCLevel;
            qrCodeOptions.Dark = configuredOptions.Dark;
            qrCodeOptions.Light = configuredOptions.Light;
            qrCodeOptions.PixelsPerModule = configuredOptions.PixelsPerModule;
            qrCodeOptions.Quality = configuredOptions.Quality;
            qrCodeOptions.Compression = configuredOptions.Compression;
            qrCodeOptions.DrawQuietZones = configuredOptions.DrawQuietZones;

            await next(context);
        }

        /// <summary>
        /// Configures default values for the API to use for qr codes.
        /// Values are extracted from appSettings.json
        /// </summary>
        /// <param name="config">The application level configuration object</param>
        private void ConfigureDefaultOptions(IConfiguration config)
        {
            try
            {
                DefaultLightColour = config.GetSection("QrCodeDefaults")["LightColour"];
                DefaultDarkColour = config.GetSection("QrCodeDefaults")["DarkColour"];
                DefaultEccLevel = config.GetSection("QrCodeDefaults")["EccLevel"];
                DefaultQuality = byte.Parse(config.GetSection("QrCodeDefaults")["Quality"]);
                DefaultCompression = byte.Parse(config.GetSection("QrCodeDefaults")["Compression"]);
                DefaultDrawQuietZones = bool.Parse(config.GetSection("QrCodeDefaults")["DrawQuietZones"]);
                DefaultPixelsPerModule = int.Parse(config.GetSection("QrCodeDefaults")["PixelsPerModule"]);
            }
            catch
            {
                throw new ArgumentException("Unable to initialize qr code options from appSettings.json. Ensure properties are set and are valid");
            }
        }

        /// <summary>
        /// Parses the HttpContext request headers to create a <see cref="QrCodeOptions"/> to use for the request.
        /// </summary>
        /// <param name="context">The current HttpContext</param>
        /// <returns>
        /// The parsed QrCodeOptions
        /// </returns>
        private QrCodeOptions ConfigureOptions(HttpContext context)
        {
            var hasEccLevel = context.Request.Query.TryGetValue("ecc", out var ecc);
            var hasValidLightColour = context.Request.Query.TryGetValue("light", out var lightColour);
            var hasValidDarkColour = context.Request.Query.TryGetValue("dark", out var darkColour);
            var hasQuietZones = context.Request.Query.TryGetValue("drawQuietZones", out var drawQuietZones);
            var hasPixelsPerModule = context.Request.Query.TryGetValue("pixelsPerModule", out var pixelsPerModule);
            var hasQuality = context.Request.Query.TryGetValue("quality", out var quality);
            var hasCompression = context.Request.Query.TryGetValue("compression", out var compression);

            return new QrCodeOptions
            {
                ECCLevel = GetEccLevel(hasEccLevel ? ecc : DefaultEccLevel),
                Light = hasValidLightColour ? ParseLightColour(lightColour) : DefaultLightColour,
                Dark = hasValidDarkColour ? ParseDarkColour(darkColour) : DefaultDarkColour,
                DrawQuietZones = hasQuietZones ? ParseDrawQuietZones(drawQuietZones) : DefaultDrawQuietZones,
                PixelsPerModule = hasPixelsPerModule ? GetPixelsPerModule(pixelsPerModule) : DefaultPixelsPerModule,
                Compression = hasCompression ? GetCompression(compression) : DefaultCompression,
                Quality = hasQuality ? GetQuality(quality) : DefaultQuality
            };
        }

        /// <summary>
        /// Gets the ECC level for the qr code.
        /// <see cref="ECCLevel"/>
        /// </summary>
        /// <param name="ecc">The string value of the ecc level</param>
        /// <returns></returns>
        private ECCLevel GetEccLevel(string ecc)
        {
            return ecc switch
            {
                "l" => ECCLevel.L,
                "q" => ECCLevel.Q,
                "h" => ECCLevel.H,
                "m" => ECCLevel.M,
                _ => GetEccLevel(DefaultEccLevel)
            };
        }

        /// <summary>
        /// Get the light colour for the qr code. If the provided code is invalid,
        /// fallsback to the default light colour
        /// </summary>
        /// <param name="colour">The colour code to use</param>
        /// <returns></returns>
        private string ParseLightColour(string colour)
        {
            if (!IsValidColourCode(colour))
            {
                return DefaultLightColour;
            }
            else return colour;
        }

        /// <summary>
        /// Get the dark colour for the qr code. If the provided code is invalid,
        /// fallsback to the default dark colour
        /// </summary>
        /// <param name="colour">The colour code to use</param>
        /// <returns></returns>
        private string ParseDarkColour(string colour)
        {
            if (!IsValidColourCode(colour))
            {
                return DefaultDarkColour;
            }
            else return colour;
        }

        /// <summary>
        /// Gets whether the api should generate the qr code with
        /// drawn quiet zones.
        /// 
        /// Truthy values: Y, Yes, True, T 
        /// Falsy values: N, No, False, F
        /// 
        /// If a value cannot be matched, falls back to default values
        /// </summary>
        /// <param name="input">The passed header value</param>
        /// <returns></returns>
        private bool ParseDrawQuietZones(string input)
        {
            var truthyValues = new string[]
            {
                "t", "true", "y", "yes"
            };

            var falsyValues = new string[]
            {
                "f", "false", "n", "no"
            };

            if (truthyValues.Contains(input.ToLower()))
            {
                return true;
            }
            else if (falsyValues.Contains(input.ToLower()))
            {
                return false;
            }
            else return DefaultDrawQuietZones;
        }

        /// <summary>
        /// Gets the pixels per module from the header.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module to parse</param>
        /// <returns></returns>
        private int GetPixelsPerModule(StringValues pixelsPerModule)
        {
            try
            {
                int amount = int.Parse(pixelsPerModule.First());

                if (amount >= 20 && amount <= 40)
                {
                    return amount;
                }

                throw new Exception("PixelsPerModule must be between 20 and 40");
            }
            catch
            {
                return DefaultPixelsPerModule;
            }
        }

        /// <summary>
        /// Parses a numeric compression from a <see cref="StringValues"/> header
        /// </summary>
        /// <param name="compression">The compression value to parse</param>
        /// <returns></returns>
        private byte GetCompression(StringValues compression)
        {
            try
            {
                var amount = byte.Parse(compression.First());

                if (amount > 0 && amount < 100)
                {
                    return amount;
                }

                throw new Exception("Compression must be between 0 and 100");
            }
            catch
            {
                return DefaultCompression;
            }
        }

        /// <summary>
        /// Parses a numeric quality from a <see cref="StringValues"/> header
        /// </summary>
        /// <param name="quality">The quality value to parse</param>
        /// <returns></returns>
        private byte GetQuality(StringValues quality)
        {
            try
            {
                var amount = byte.Parse(quality.First());

                if (amount > 0 && amount < 100)
                {
                    return amount;
                }

                throw new Exception("Quality must be between 0 and 100");
            }
            catch
            {
                return DefaultQuality;
            }
        }

        /// <summary>
        /// Valides a hexadecimal colour code (with the #)
        /// </summary>
        /// <param name="colourCode">The colour code to validate.</param>
        /// <returns> True if the colour code is valid</returns>
        private static bool IsValidColourCode(string colourCode)
        {
            var regex = new Regex(@"^#[0-9A-F]{6}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (regex.Match(colourCode).Success)
            {
                return true;
            }
            else return false;
        }
    }
}
