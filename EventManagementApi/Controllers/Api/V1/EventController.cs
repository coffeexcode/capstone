using EventManagementApi.Core.Exceptions;
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
    [Route("api/v1/events")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> logger;
        private readonly IEventService eventService;

        public EventController(
            ILogger<EventController> logger,
            IEventService eventService)
        {
            this.logger = logger;
            this.eventService = eventService;
        }

        /// <summary>
        /// Returns a list of all available events
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/events
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created events
        /// </returns>
        /// <response code="200">Returns the list of created events</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Event>>> GetEvents()
        {
            try
            {
                var result = await eventService.GetEventsAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a event based on the provided event ID.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/events/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// The event with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns event with matching id </response>
        /// <response code="404">Event with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> GetEventById(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                return NotFound();
            }

            try
            {
                var @event = await eventService.GetEventByIdAsync(eventId);

                if (eventId == null)
                {
                    return NotFound();
                }
                else return Ok(@event);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="model">Event to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/events
        ///     {
        ///         "name": "Introduction to Hazmat",
        ///         "description": "In this event, students will get an introduction to the wonderful world of hazardous materials",
        ///         "start": "2020-11-20T13:00:00",
        ///         "end": "2020-11-20T14:00:00",
        ///         "roomId": "36983f19-d400-439d-9988-567d01682615"
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
        public async Task<ActionResult<Event>> CreateEvent([FromBody] EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await eventService.CreateEventAsync(model);

                return CreatedAtAction(nameof(GetEventById), new { eventId = created.Id }, created);
            }
            catch (EntityNotFoundException e)
            {
                ModelState.AddModelError("RoomId", "The provided roomId was not found");
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a event.
        /// </summary>
        /// <param name="eventId">The event to update.</param>
        /// <param name="patchDocument">JsonPatch document with operation to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/events/01627d18-1fc9-4a75-82c9-1e707f216c25
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
        /// The updated event with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated event with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Event with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>   
        [HttpPatch("{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Event>> UpdateEvent(string eventId,
            [FromBody] JsonPatchDocument<EventViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await eventService.UpdateEventAsync(eventId, patchDocument);

                return Ok(updated);
            }
            catch (EntityNotFoundException e)
            {
                ModelState.AddModelError("RoomId", "The provided roomId was not found");
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a event.
        /// </summary>
        /// <param name="eventId">The event to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/events/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The event was deleted</response>
        /// <response code="404">Event with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEvent(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                return NotFound();
            }

            try
            {
                await eventService.DeleteEventAsync(eventId);

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
