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
    [Route("api/v1/courses")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> logger;
        private readonly ICourseService courseService;
        public CourseController(
            ILogger<CourseController> logger,
            ICourseService courseService)
        {
            this.logger = logger;
            this.courseService = courseService;
        }

        /// <summary>
        /// Gets all courses
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/courses
        ///
        /// </remarks>
        /// <returns>
        /// A list of all created courses
        /// </returns>
        /// <response code="200">Returns the list of created courses</response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Course>>> GetCourses()
        {
            try
            {
                var courses = await courseService.GetCoursesAsync();

                return Ok(courses);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Creates a course
        /// </summary>
        /// <param name="model">The course to create</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/courses
        ///     {
        ///         "name": "Introduction to Hazmat",
        ///         "description": "In this course, students will get an introduction to the wonderful world of hazardous materials"
        ///     }
        /// </remarks>
        /// <returns>
        /// The newly created course
        /// </returns>
        /// <response code="201">Returns the newly created course </response>
        /// <response code="400">Model validation failed </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourse([FromBody] CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await courseService.CreateCourseAsync(model);

                return CreatedAtAction(nameof(GetCourseById), new { courseId = created.Id }, created);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Gets a course
        /// </summary>
        /// <param name="courseId">The course with ID to get</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/courses/01627d18-1fc9-4a75-82c9-1e707f216c25
        /// </remarks>
        /// <returns>
        /// The course with matching id, if it exists
        /// </returns>
        /// <response code="200">Returns course with matching id </response>
        /// <response code="404">Course with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpGet("{courseId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Course>> GetCourseById(string courseId)
        {
            if (string.IsNullOrEmpty(courseId))
            {
                return NotFound();
            }

            try
            {
                var course = await courseService.GetCourseByIdAsync(courseId);

                if (course == null)
                {
                    return NotFound();
                } else return Ok(course);
            } catch (Exception e)
            {
                return await HandleControllerException(e);
            }
        }

        /// <summary>
        /// Updates a course.
        /// </summary>
        /// <param name="courseId">The course to update.</param>
        /// <param name="patchDocument">JsonPatch document with operations to perform.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/v1/courses/01627d18-1fc9-4a75-82c9-1e707f216c25
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
        /// <response code="404">Course with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpPatch("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Course>> UpdateCourse(string courseId,
            [FromBody] JsonPatchDocument<CourseViewModel> patchDocument)
        {
            if (string.IsNullOrEmpty(courseId))
            {
                return NotFound();
            }

            if (patchDocument == null)
            {
                return BadRequest("Invalid JsonPatch");
            }

            try
            {
                var updated = await courseService.UpdateCourseAsync(courseId, patchDocument);

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
        /// <param name="courseId">The course to delete.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/courses/01627d18-1fc9-4a75-82c9-1e707f216c25
        ///     
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        /// <response code="200">The course was deleted</response>
        /// <response code="404">Course with ID was not found </response>
        /// <response code="500">If the server cannot process the request</response>    
        [HttpDelete("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse(string courseId)
        {
            if (string.IsNullOrEmpty(courseId))
            {
                return NotFound();
            }

            try
            {
                await courseService.DeleteCourseAsync(courseId);

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
