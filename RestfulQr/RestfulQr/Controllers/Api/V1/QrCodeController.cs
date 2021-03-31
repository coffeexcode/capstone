using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulQr.Services;
using RestfulQr.ViewModels;
using Serilog;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestfulQr.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/qrcode")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public class QrCodeController : ControllerBase
    {
        private readonly IQrCodeService qrCodeService;
        private readonly IImageFileService imageFileService;

        public QrCodeController(
            IQrCodeService qrCodeService,
            IImageFileService imageFileService)
        {
            this.qrCodeService = qrCodeService;
            this.imageFileService = imageFileService;
        }

        /// <summary>
        /// Encodes a valid json object into a qr code
        /// </summary>
        /// <param name="content">The object to encode</param>
        /// <returns>
        /// The result of creation, including the location of the created file
        /// </returns>
        /// <response code="201">Returns the newly created qr code</response>
        /// <response code="400">The json was not found or invalid</response>
        /// <response code="500">The qr code not be created</response>   
        [HttpPost("json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateQrCodeResult>> Json(object content)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(content, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (string.IsNullOrEmpty(jsonContent))
                {
                    return BadRequest("JSON body as not or an invalid format");
                }

                var result = await qrCodeService.CreateJsonQrCodeAsync(jsonContent);

                if (result.Succeeded)
                {
                    result.Data = content;

                    return Created(BuildAppUrl(result.CreatedQrCode.Filename), result);
                }

                throw new Exception("Error creating qr code");
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to create a QR code");

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Builds the URL for the app
        /// </summary>
        /// <param name="filename">The filename that the path should point to</param>
        /// <returns> A publiclly accesible URL to access the file</returns>
        private string BuildAppUrl(string filename)
        {
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{imageFileService.GetImagePath()}/{filename}";
        }
    }
}
