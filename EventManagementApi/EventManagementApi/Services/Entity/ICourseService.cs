using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    /// <summary>
    /// Provides CRUD functionality for courses.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Creates a course
        /// </summary>
        /// <param name="model">The model to use to create the course </param>
        /// <returns>The created course, otherwise null. </returns>
        public Task<Course> CreateCourseAsync(CourseViewModel model);

        /// <summary>
        /// Gets all course.
        /// </summary>
        /// <returns>A list of all course. </returns>
        public Task<IList<Course>> GetCoursesAsync();

        /// <summary>
        /// Gets a single course by its unique id.
        /// </summary>
        /// <param name="courseId">The id of the course  to find.</param>
        /// <returns>The course, otherwise null. </returns>
        public Task<Course> GetCourseByIdAsync(string courseId);

        /// <summary>
        /// Updates a course
        /// </summary>
        /// <param name="courseId">The course to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the course</param>
        /// <returns>The updated course, otherwise the existing one if an error occurs.</returns>
        public Task<Course> UpdateCourseAsync(string courseId, JsonPatchDocument<CourseViewModel> patchDocument);

        /// <summary>
        /// Deletes a course
        /// </summary>
        /// <param name="courseId">The id of the course to delete.</param>
        /// <returns></returns>
        public Task DeleteCourseAsync(string courseId);
    }
}
