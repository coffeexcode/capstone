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
    [Route("api/v1/locations")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> logger;
        private readonly ILocationService locationService;

        public LocationController(
            ILogger<LocationController> logger,
            ILocationService locationService)
        {
            this.logger = logger;
            this.locationService = locationService;
        }

        /// <summary>
        /// Returns a list of all available locations
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/locations
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created locations
        /// </returns>
        /// <response code="200">Returns the list of created locations</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Location>>> GetLocations()
        {
            try
            {
                var result = await locationService.GetLocationsAsync();

                return Ok(result);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a new location
        /// </summary>
        /// <param name="model">Location to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/locations
        ///     {
        ///         "name": "Location A",
        ///         "description": "Location A is the hilton hotel in Hamilton, Ontario",
        ///         "line1": "123 Main St E",
        ///         "city": "Hamilton",
        ///         "region": "Ontario",
        ///         "country": "Canada",
        ///         "areaCode": "A1A 2B2"
        ///     }
        ///     
        /// </remarks>
        /// <returns>
        /// The newly created location
        /// </returns>
        /// <response code="201">Returns the newly created location </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Location>> CreateLocation([FromBody] LocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await locationService.CreateLocationAsync(model);

                return CreatedAtAction(nameof(GetLocationById), new { locationId = created.Id }, created);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a location based on the provided location ID.
        /// </summary>
        /// <param name="locationId">The ID of the location to retrieve.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/locations/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// The location with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns location with matching id </response>
        /// <response code="404">Location with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{locationId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Location>> GetLocationById(string locationId)
        {
            if (string.IsNullOrEmpty(locationId))
            {
                return NotFound();
            }

            try
            {
                var location = await locationService.GetLocationByIdAsync(locationId);

                if (location == null)
                {
                    return NotFound();
                } 
                else return Ok(location);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="locationId">The location to update.</param>
        /// <param name="patchDocument">JsonPatch document with operation to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/locations/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/name",
        ///                 "value": "New Location"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated location with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated location with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Location with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{locationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Location>> UpdateLocation(string locationId, 
            [FromBody] JsonPatchDocument<LocationViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(locationId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await locationService.UpdateLocationAsync(locationId, patchDocument);

                return Ok(updated);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="locationId">The location to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/locations/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The location was deleted</response>
        /// <response code="404">Location with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{locationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLocation(string locationId)
        {
            if (string.IsNullOrEmpty(locationId))
            {
                return NotFound();
            }

            try
            {
                await locationService.DeleteLocationAsync(locationId);

                return Ok();
            } catch (Exception e)
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
