using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for courses.
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Creates a course regiustration in the backing database.
        /// </summary>
        /// <param name="course">The course to create in the database. </param>
        /// <returns>The created course as in the database. </returns>
        public Task<Course> CreateCourseAsync(Course course);

        /// <summary>
        /// Gets all courses in the backing database.
        /// </summary>
        /// <returns>A list of all courses registrations. </returns>
        public Task<IList<Course>> GetCoursesAsync();

        /// <summary>
        /// Gets single course by its unique id.
        /// </summary>
        /// <param name="courseId">The id of the course to find.</param>
        /// <returns>The course, otherwise null. </returns>
        public Task<Course> GetCourseByIdAsync(string courseId);

        /// <summary>
        /// Updates a course.
        /// </summary>
        /// <param name="courseId">The id of the course to update in the database. </param>
        /// <param name="course">The course entity to overwrite with. </param>
        /// <returns>The updated course, otherwise the existing one if an error occurs.</returns>
        public Task<Course> UpdateCourseAsync(string courseId, Course course);

        /// <summary>
        /// Deletes a course.
        /// </summary>
        /// <param name="courseId">The id of the course to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteCourseAsync(string courseId);
    }
}
