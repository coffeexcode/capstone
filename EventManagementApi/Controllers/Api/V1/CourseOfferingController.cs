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
    [Route("api/v1/courseofferings")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CourseOfferingController : ControllerBase
    {
        private readonly ICourseOfferingService courseOfferingService;

        public CourseOfferingController(ICourseOfferingService courseOfferingService)
        {
            this.courseOfferingService = courseOfferingService;
        }

        /// <summary>
        /// Gets all course offerings
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/courseofferings
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created course offerings
        /// </returns>
        /// <response code="200">Returns the list of created course offerings</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<CourseOffering>>> GetCourseOfferings()
        {
            try
            {
                var courses = await courseOfferingService.GetCourseOfferingsAsync();

                return Ok(courses);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a course offering
        /// </summary>
        /// <param name="model">The course offering to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/courseofferings
        ///     {
        ///         "name": "Introduction to Hazmat",
        ///         "description": "In this course, students will get an introduction to the wonderful world of hazardous materials"
        ///     }
        /// </remarks>
        /// <returns>
        /// The newly created course offering
        /// </returns>
        /// <response code="201">Returns the newly created course offering</response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourse([FromBody] CourseOfferingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await courseOfferingService.CreateCourseOfferingAsync(model);

                return CreatedAtAction(nameof(GetCourseOfferingById), new { courseOfferingId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a course offering
        /// </summary>
        /// <param name="courseOfferingId">The course offering with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/courseofferingss/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The course offering with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns course offering with matching id </response>
        /// <response code="404">Course offering with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{courseOfferingId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseOffering>> GetCourseOfferingById(string courseOfferingId)
        {
            if (string.IsNullOrEmpty(courseOfferingId))
            {
                return NotFound();
            }

            try
            {
                var course = await courseOfferingService.GetCourseOfferingByIdAsync(courseOfferingId);

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
        /// Updates a course offering.
        /// </summary>
        /// <param name="courseOfferingId">The course offering to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/courseofferings/01627d18-1fc9-4a75-82c9-1e707f216c25
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
        /// The updated course offering with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated course offering with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Course offering with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{courseOfferingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseOffering>> UpdateCourse(string courseOfferingId,
            [FromBody] JsonPatchDocument<CourseOfferingViewModel> patchDocument)
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
                var updated = await courseOfferingService.UpdateCourseOfferingAsync(courseOfferingId, patchDocument);

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
        /// <param name="courseOfferingId">The course offering to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/courseofferings/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The course offering was deleted</response>
        /// <response code="404">Course offering with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{courseOfferingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse(string courseOfferingId)
        {
            if (string.IsNullOrEmpty(courseOfferingId))
            {
                return NotFound();
            }

            try
            {
                await courseOfferingService.DeleteCourseOfferingAsync(courseOfferingId);

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
