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
    [Route("api/v1/course-offering-registrations")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CourseOfferingRegistrationController : ControllerBase
    {
        private readonly ICourseOfferingRegistrationService courseOfferingRegistrationService;

        public CourseOfferingRegistrationController(ICourseOfferingRegistrationService courseOfferingRegistrationService)
        {
            this.courseOfferingRegistrationService = courseOfferingRegistrationService;
        }

        /// <summary>
        /// Gets all course offering registrations
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/courseofferingregistrations
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created course offering registrations
        /// </returns>
        /// <response code="200">Returns the list of created course offering registrations. </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<CourseOfferingRegistration>>> GetCourseOfferingRegistrations()
        {
            try
            {
                var courseOfferingRegistrations = await courseOfferingRegistrationService.GetCourseOfferingRegistrationsAsync();

                return Ok(courseOfferingRegistrations);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a course offering registration
        /// </summary>
        /// <param name="model">The course offering registration to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/courseofferingregistrations
        ///     {
        ///         "name": "Introduction to Hazmat",
        ///         "description": "In this course, students will get an introduction to the wonderful world of hazardous materials"
        ///     }
        /// </remarks>
        /// <returns>
        /// The newly created course
        /// </returns>
        /// <response code="201">Returns the newly created course offering registration</response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourseOfferingRegistration([FromBody] CourseOfferingRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await courseOfferingRegistrationService.CreateCourseOfferingRegistrationAsync(model);

                return CreatedAtAction(nameof(GetCourseOfferingRegistrationById), new { courseOfferingRegistrationId = created.Id }, created);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a course offering registration
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The course offering registration with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/courseofferingregistrations/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The course offering registration with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns course offering registration with matching id </response>
        /// <response code="404">Course offering registration with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{courseOfferingRegistrationId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseOfferingRegistration>> GetCourseOfferingRegistrationById(string courseOfferingRegistrationId)
        {
            if (string.IsNullOrEmpty(courseOfferingRegistrationId))
            {
                return NotFound();
            }

            try
            {
                var courseOfferingRegistration = await courseOfferingRegistrationService.GetCourseOfferingRegistrationByIdAsync(courseOfferingRegistrationId);

                if (courseOfferingRegistration == null)
                {
                    return NotFound();
                }
                else return Ok(courseOfferingRegistration);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a course offering registration.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The course offering registration to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/courseofferingregistrations/01627d18-1fc9-4a75-82c9-1e707f216c25
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
        /// The updated course with matching id, if it exists
        /// </returns>
        /// <response code="201">Returns updated course with matching id </response>
        /// <response code="400">Model validation failed or invalid JSONPatch document </response>
        /// <response code="404">Course offering registration with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{courseOfferingRegistrationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseOfferingRegistration>> UpdateCourse(string courseOfferingRegistrationId,
            [FromBody] JsonPatchDocument<CourseOfferingRegistrationViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(courseOfferingRegistrationId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await courseOfferingRegistrationService.UpdateCourseOfferingRegistrationAsync(courseOfferingRegistrationId, patchDocument);

                return Ok(updated);
            }
            catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Deletes a course offering registration.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The course offering registration to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/eventofferingregistrations/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The course offering registration was deleted</response>
        /// <response code="404">Course offering registration with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse(string courseOfferingRegistrationId)
        {
            if (string.IsNullOrEmpty(courseOfferingRegistrationId))
            {
                return NotFound();
            }

            try
            {
                await courseOfferingRegistrationService.DeleteCourseOfferingRegistrationAsync(courseOfferingRegistrationId);

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
