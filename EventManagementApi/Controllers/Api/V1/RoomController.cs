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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/rooms")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> logger;
        private readonly IRoomService roomService;

        public RoomController(
            ILogger<RoomController> logger,
            IRoomService roomService)
        {
            this.logger = logger;
            this.roomService = roomService;
        }

        /// <summary>
        /// Gets all rooms
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/rooms
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created rooms
        /// </returns>
        /// <response code="200">Returns the list of created rooms</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Room>>> GetRooms()
        {
            try
            {
                var rooms = await roomService.GetRoomsAsync();

                return Ok(rooms);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a room
        /// </summary>
        /// <param name="model">The room to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/rooms
        ///     {
        ///         "name": "The Hot Zone",
        ///         "description": "Hazardous Materials Conference Room A",
        ///         "capacity": 25,
        ///         "locationId": "c2f36ace-05c2-4b44-90c8-c14517b87a68"
        ///     }
        ///     
        /// </remarks>
        /// <returns>
        /// The newly created room
        /// </returns>
        /// <response code="201">Returns the newly created room </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> CreateRoom([FromBody] RoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await roomService.CreateRoomAsync(model);

                return CreatedAtAction(nameof(GetRoomById), new { roomId = created.Id }, created);
            }
            catch (EntityNotFoundException e)
            {
                ModelState.AddModelError("locationId", "The provided locationId was not found");
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a room
        /// </summary>
        /// <param name="roomId">The room with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/rooms/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// The room with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns room with matching id </response>
        /// <response code="404">Room with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{roomId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> GetRoomById(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                return NotFound();
            }

            try
            {
                var room = await roomService.GetRoomByIdAsync(roomId);

                if (room == null)
                {
                    return NotFound();
                }
                else return Ok(room);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="roomId">The room to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/rooms/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/name",
        ///                 "value": "New Room"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated room with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated room with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Room with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> UpdateRoomById(string roomId, JsonPatchDocument<RoomViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await roomService.UpdateRoomAsync(roomId, patchDocument);

                return Ok(updated);
            }
            catch (EntityNotFoundException e)
            {
                ModelState.AddModelError("locationId", "The provided locationId was not found");
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a room.
        /// </summary>
        /// <param name="roomId">The room to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/rooms/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The room was deleted</response>
        /// <response code="404">Room with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRoom(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                return NotFound();
            }

            try
            {
                await roomService.DeleteRoomAsync(roomId);

                return Ok();
            } catch (Exception e)
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
