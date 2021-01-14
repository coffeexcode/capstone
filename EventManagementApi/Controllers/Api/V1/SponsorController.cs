using EventManagementApi.Entities;
using EventManagementApi.Services.Entity;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementApi.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/sponsors")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SponsorController : ControllerBase
    {
        private readonly ILogger<SponsorController> logger;
        private readonly ISponsorService sponsorService;

        public SponsorController(
            ILogger<SponsorController> logger,
            ISponsorService sponsorService)
        {
            this.logger = logger;
            this.sponsorService = sponsorService;
        }

        /// <summary>
        /// Gets all sponsors
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/sponsors
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created sponsors
        /// </returns>
        /// <response code="200">Returns the list of created sponsors</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Sponsor>>> GetSponsors()
        {
            try
            {
                var result = await sponsorService.GetSponsorsAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a sponsor
        /// </summary>
        /// <param name="model">The sponsor to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/sponsors
        ///     {
        ///         "name": "Hamilton Bio Services",
        ///         "contactFirstName": "John",
        ///         "contactLastName": "Doe",
        ///         "contactEmail": "john.doe@hamiltonbio.ca",
        ///         "contactPhone": "905-987-6543 ex 21"
        ///     }
        ///     
        /// </remarks>
        /// <returns>
        /// The newly created sponsor
        /// </returns>
        /// <response code="201">Returns the newly created sponsor </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Sponsor>> CreateSponsor([FromBody] SponsorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await sponsorService.CreateSponsorAsync(model);

                return CreatedAtAction(nameof(GetSponsorById), new { sponsorId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a sponsor
        /// </summary>
        /// <param name="sponsorId">The sponsor with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/sponsors/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// The sponsor with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns sponsor with matching id </response>
        /// <response code="404">Sponsor with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{sponsorId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Sponsor>> GetSponsorById(string sponsorId)
        {
            if (string.IsNullOrEmpty(sponsorId))
            {
                return NotFound();
            }

            try
            {
                var sponsor = await sponsorService.GetSponsorByIdAsync(sponsorId);

                if (sponsor == null)
                {
                    return NotFound();
                }
                else return Ok(sponsor);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a sponsor.
        /// </summary>
        /// <param name="sponsorId">The sponsor to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/sponsors/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/name",
        ///                 "value": "New Sponsor"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated sponsor with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated sponsor with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Sponsor with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{sponsorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Sponsor>> UpdateSponsor(string sponsorId,
            [FromBody] JsonPatchDocument<SponsorViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(sponsorId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await sponsorService.UpdateSponsorAsync(sponsorId, patchDocument);

                return Ok(updated);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a sponsor.
        /// </summary>
        /// <param name="sponsorId">The sponsor to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/sponsors/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The sponsor was deleted</response>
        /// <response code="404">Sponsor with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{sponsorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSponsor(string sponsorId)
        {
            if (string.IsNullOrEmpty(sponsorId))
            {
                return NotFound();
            }

            try
            {
                await sponsorService.DeleteSponsorAsync(sponsorId);

                return Ok();
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }


        /// <summary>
        /// Some server error has occured while processing that was unrecoverable. 
        /// Return 500 to the user and post the message that caused the unrecoverable 
        /// error.
        /// </summary>
        /// <param name="e">The unrecoverable exception</param>
        /// <returns>StatusCode 500</returns>
        private async Task<ActionResult> HandleControllerException(Exception e)
        {
            await Task.Yield();

            return StatusCode(500, e);
        }
    }
}
