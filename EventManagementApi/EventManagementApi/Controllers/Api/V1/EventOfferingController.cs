using EventManagementApi.Entities;
using EventManagementApi.Services.Entity;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/eventofferings")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class EventOfferingController : ControllerBase
    {
        private readonly IEventOfferingService eventOfferingService;

        public EventOfferingController(IEventOfferingService eventOfferingService)
        {
            this.eventOfferingService = eventOfferingService;
        }

        /// <summary>
        /// Gets all event offerings
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/eventofferings
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created event offerings
        /// </returns>
        /// <response code="200">Returns the list of created event offerings</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<EventOffering>>> GetEventOfferings()
        {
            try
            {
                var courses = await eventOfferingService.GetEventOfferingsAsync();

                return Ok(courses);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a event offering
        /// </summary>
        /// <param name="model">The event offering to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/eventofferings
        ///     {
        ///         "name": "Introduction to Hazmat",
        ///         "description": "In this course, students will get an introduction to the wonderful world of hazardous materials"
        ///     }
        /// </remarks>
        /// <returns>
        /// The newly created event offering
        /// </returns>
        /// <response code="201">Returns the newly created event offering</response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEvent([FromBody] EventOfferingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await eventOfferingService.CreateEventOfferingAsync(model);

                return CreatedAtAction(nameof(GetEventOfferingById), new { courseOfferingId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a event offering
        /// </summary>
        /// <param name="courseOfferingId">The event offering with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/eventofferingss/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The event offering with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns event offering with matching id </response>
        /// <response code="404">Event offering with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{courseOfferingId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventOffering>> GetEventOfferingById(string courseOfferingId)
        {
            if (string.IsNullOrEmpty(courseOfferingId))
            {
                return NotFound();
            }

            try
            {
                var course = await eventOfferingService.GetEventOfferingByIdAsync(courseOfferingId);

                if (course == null)
                {
                    return NotFound();
                }
                else return Ok(course);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a event offering.
        /// </summary>
        /// <param name="courseOfferingId">The event offering to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/eventofferings/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/name",
        ///                 "value": "New Event"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated event offering with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated event offering with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Event offering with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{courseOfferingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventOffering>> UpdateEvent(string courseOfferingId,
            [FromBody] JsonPatchDocument<EventOfferingViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(courseOfferingId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await eventOfferingService.UpdateEventOfferingAsync(courseOfferingId, patchDocument);

                return Ok(updated);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a course.
        /// </summary>
        /// <param name="courseOfferingId">The event offering to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/eventofferings/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The event offering was deleted</response>
        /// <response code="404">Event offering with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{courseOfferingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEvent(string courseOfferingId)
        {
            if (string.IsNullOrEmpty(courseOfferingId))
            {
                return NotFound();
            }

            try
            {
                await eventOfferingService.DeleteEventOfferingAsync(courseOfferingId);

                return Ok();
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }


        private async Task<ActionResult> HandleControllerException(Exception e)
        {
            await Task.Yield();
            return StatusCode(500, e);
        }
    }
}
