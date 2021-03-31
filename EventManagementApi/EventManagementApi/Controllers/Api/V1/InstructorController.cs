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
    [Route("api/v1/instructors")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class InstructorController : ControllerBase
    {
        private readonly ILogger<InstructorController> logger;
        private readonly IInstructorService instructorService;

        public InstructorController(
            ILogger<InstructorController> logger,
            IInstructorService instructorService)
        {
            this.logger = logger;
            this.instructorService = instructorService;
        }

        /// <summary>
        /// Returns a list of all available instructors
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/instructors
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created instructors
        /// </returns>
        /// <response code="200">Returns the list of created instructors</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Instructor>>> GetInstructors()
        {
            try
            {
                var result = await instructorService.GetInstructorsAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a new instructor
        /// </summary>
        /// <param name="model">Instructor to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/instructors
        ///     {
        ///         "firstName": "Nathan",
        ///         "lastName": "Brown",
        ///         "email": "brownn11@mcmaster.ca",
        ///         "phone": "905-123-4567"
        ///     }
        ///     
        /// </remarks>
        /// <returns>
        /// The newly created instructor
        /// </returns>
        /// <response code="201">Returns the newly created instructor </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Instructor>> CreateInstructor([FromBody] InstructorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await instructorService.CreateInstructorAsync(model);

                return CreatedAtAction(nameof(GetInstructorById), new { instructorId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a instructor based on the provided instructor ID.
        /// </summary>
        /// <param name="instructorId">The ID of the instructor to retrieve.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/instructors/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The instructor with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns instructor with matching id </response>
        /// <response code="404">Instructor with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{instructorId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Instructor>> GetInstructorById(string instructorId)
        {
            if (string.IsNullOrEmpty(instructorId))
            {
                return NotFound();
            }

            try
            {
                var instructor = await instructorService.GetInstructorByIdAsync(instructorId);

                if (instructor == null)
                {
                    return NotFound();
                }
                else return Ok(instructor);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a instructor.
        /// </summary>
        /// <param name="instructorId">The instructor to update.</param>
        /// <param name="patchDocument">JsonPatch document with operation to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/instructors/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     {
        ///         [
        ///             {
        ///                 "op": "replace",
        ///                 "path": "/firstName",
        ///                 "value": "John"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>
        /// The updated instructor with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated instructor with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Instructor with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{instructorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Instructor>> UpdateInstructor(string instructorId,
            [FromBody] JsonPatchDocument<InstructorViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(instructorId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await instructorService.UpdateInstructorAsync(instructorId, patchDocument);

                return Ok(updated);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a instructor.
        /// </summary>
        /// <param name="instructorId">The instructor to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/instructors/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The instructor was deleted</response>
        /// <response code="404">Instructor with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{instructorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInstructor(string instructorId)
        {
            if (string.IsNullOrEmpty(instructorId))
            {
                return NotFound();
            }

            try
            {
                await instructorService.DeleteInstructorAsync(instructorId);

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
