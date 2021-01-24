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
    [Route("api/v1/timeslot")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TimeslotController : ControllerBase
    {
        private readonly ILogger<TimeslotController> logger;
        private readonly ITimeslotService timeslotService;

        public TimeslotController(
            ILogger<TimeslotController> logger,
            ITimeslotService timeslotService)
        {
            this.logger = logger;
            this.timeslotService = timeslotService;
        }

        /// <summary>
        /// Gets all timeslots
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/timeslots
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created timeslots
        /// </returns>
        /// <response code="200">Returns the list of created timeslots</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Timeslot>>> GetTimeslots()
        {
            try
            {
                var result = await timeslotService.GetTimeslotsAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a timeslot
        /// </summary>
        /// <param name="model">The timeslot to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/timeslots
        ///     {
        ///         "name": "1A",
        ///         "start": "2020-11-20T13:00:00",
        ///         "end": "2020-11-20T14:00:00"
        ///     }
        ///     
        /// </remarks>
        /// <returns>
        /// The newly created timeslot
        /// </returns>
        /// <response code="201">Returns the newly created timeslot </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Timeslot>> CreateTimeslot([FromBody] TimeslotViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await timeslotService.CreateTimeslotAsync(model);

                return CreatedAtAction(nameof(GetTimeslotById), new { timeslotId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a timeslot
        /// </summary>
        /// <param name="timeslotId">The timeslot with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/timeslots/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The timeslot with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns timeslot with matching id </response>
        /// <response code="404">Timeslot with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{timeslotId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Timeslot>> GetTimeslotById(string timeslotId)
        {
            if (string.IsNullOrEmpty(timeslotId))
            {
                return NotFound();
            }

            try
            {
                var timeslot = await timeslotService.GetTimeslotByIdAsync(timeslotId);

                if (timeslot == null)
                {
                    return NotFound();
                }
                else return Ok(timeslot);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a timeslot.
        /// </summary>
        /// <param name="timeslotId">The timeslot to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/timeslots/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/name",
        ///                 "value": "New Timeslot"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated timeslot with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated timeslot with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Timeslot with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{timeslotId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Timeslot>> UpdateTimeslot(string timeslotId,
            [FromBody] JsonPatchDocument<TimeslotViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(timeslotId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await timeslotService.UpdateTimeslotAsync(timeslotId, patchDocument);

                return Ok(updated);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a timeslot.
        /// </summary>
        /// <param name="timeslotId">The timeslot to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/timeslots/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The timeslot was deleted</response>
        /// <response code="404">Timeslot with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{timeslotId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTimeslot(string timeslotId)
        {
            if (string.IsNullOrEmpty(timeslotId))
            {
                return NotFound();
            }

            try
            {
                await timeslotService.DeleteTimeslotAsync(timeslotId);

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
