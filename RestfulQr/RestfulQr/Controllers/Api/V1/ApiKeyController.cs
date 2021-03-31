using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulQr.Services;
using RestfulQr.ViewModels;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulQr.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/apiKey")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [AllowAnonymous]
    public class ApiKeyController : ControllerBase
    {
        private readonly IApiKeyService apiKeyService;

        public ApiKeyController(
            IApiKeyService apiKeyService)
        {
            this.apiKeyService = apiKeyService;
        }

        /// <summary>
        /// Creates a new api key.
        /// </summary>
        /// <returns>A newly created api key</returns>
        /// <response code="201">Returns the newly created api key</response>
        /// <response code="500">The api key could not be created or saved</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateApiKeyResult>> Create()
        {
            try
            {
                var result = await apiKeyService.CreateApiKeyAsync();

                if (result.Succeeded)
                {
                    return Created(string.Empty, result);
                }
                else return BadRequest(result.Errors);
            }
            catch (Exception e)
            {
                Log.Error(e, "An error occured while creating a new api key");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deletes an api key.
        /// </summary>
        /// <remarks>
        /// Requires the provided X-Api-Key header value to match the route param key.
        /// </remarks>
        /// <param name="apiKey">The api key to delete</param>
        /// <response code="200">The operation was successful</response>
        /// <response code="401">User is not authorized to perform the operation</response>
        /// <response code="500">The api key could not be deleted</response>   
        [Authorize]
        [HttpDelete("{apiKey}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string apiKey)
        {
            if (apiKey != HttpContext.User.Claims.FirstOrDefault(c => c.Type == "apiKey")?.Value)
            {
                return Unauthorized();
            }

            try
            {
                await apiKeyService.DeleteApiKeyAsync(apiKey);

                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e, $"An error occured while trying to delete an api key '{apiKey}'");
                return StatusCode(500);
            }
        }
    }
}
