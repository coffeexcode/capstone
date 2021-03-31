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
    [Route("api/v1/event-offering-registrations")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class EventOfferingRegistrationController : ControllerBase
    {
        private readonly IEventOfferingRegistrationService eventOfferingRegistrationService;

        public EventOfferingRegistrationController(IEventOfferingRegistrationService eventOfferingRegistrationService)
        {
            this.eventOfferingRegistrationService = eventOfferingRegistrationService;
        }

        /// <summary>
        /// Gets all event offering registrations
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/eventofferingregistrations
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created event offering registrations
        /// </returns>
        /// <response code="200">Returns the list of created event offering registrations. </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<EventOfferingRegistration>>> GetEventOfferingRegistrations()
        {
            try
            {
                var eventOfferingRegistrations = await eventOfferingRegistrationService.GetEventOfferingRegistrationsAsync();

                return Ok(eventOfferingRegistrations);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a event offering registration
        /// </summary>
        /// <param name="model">The event offering registration to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/eventofferingregistrations
        ///     {
        ///         "name": "Introduction to Hazmat",
        ///         "description": "In this course, students will get an introduction to the wonderful world of hazardous materials"
        ///     }
        /// </remarks>
        /// <returns>
        /// The newly created event
        /// </returns>
        /// <response code="201">Returns the newly created event </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEventOfferingRegistration([FromBody] EventOfferingRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await eventOfferingRegistrationService.CreateEventOfferingRegistrationAsync(model);

                return CreatedAtAction(nameof(GetEventOfferingRegistrationById), new { eventOfferingRegistrationId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a event offering registration
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The event offering registration with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/eventofferingregistrations/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The event offering registration with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns event offering registration with matching id </response>
        /// <response code="404">Course offering registration with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{eventOfferingRegistrationId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventOfferingRegistration>> GetEventOfferingRegistrationById(string eventOfferingRegistrationId)
        {
            if (string.IsNullOrEmpty(eventOfferingRegistrationId))
            {
                return NotFound();
            }

            try
            {
                var eventOfferingRegistration = await eventOfferingRegistrationService.GetEventOfferingRegistrationByIdAsync(eventOfferingRegistrationId);

                if (eventOfferingRegistration == null)
                {
                    return NotFound();
                }
                else return Ok(eventOfferingRegistration);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a event offering registration.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The event offering registration to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/eventofferingregistrations/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/name",
        ///                 "value": "New Course"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated event with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated event with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Course offering registration with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{eventOfferingRegistrationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventOfferingRegistration>> UpdateCourse(string eventOfferingRegistrationId,
            [FromBody] JsonPatchDocument<EventOfferingRegistrationViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(eventOfferingRegistrationId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await eventOfferingRegistrationService.UpdateEventOfferingRegistrationAsync(eventOfferingRegistrationId, patchDocument);

                return Ok(updated);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a event offering registration.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The event offering registration to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/eventofferingregistrations/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The event offering registration was deleted</response>
        /// <response code="404">Course offering registration with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse(string eventOfferingRegistrationId)
        {
            if (string.IsNullOrEmpty(eventOfferingRegistrationId))
            {
                return NotFound();
            }

            try
            {
                await eventOfferingRegistrationService.DeleteEventOfferingRegistrationAsync(eventOfferingRegistrationId);

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
