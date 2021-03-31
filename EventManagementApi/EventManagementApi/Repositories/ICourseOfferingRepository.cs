using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for course offerings.
    /// </summary>
    public interface ICourseOfferingRepository
    {
        /// <summary>
        /// Creates a course offering regiustration in the backing database.
        /// </summary>
        /// <param name="courseOffering">The course offering to create in the database. </param>
        /// <returns>The created course offering as in the database. </returns>
        public Task<CourseOffering> CreateCourseOfferingAsync(CourseOffering courseOffering);

        /// <summary>
        /// Gets all course offerings in the backing database.
        /// </summary>
        /// <returns>A list of all course offerings registrations. </returns>
        public Task<IList<CourseOffering>> GetCourseOfferingsAsync();

        /// <summary>
        /// Gets single course offering by its unique id.
        /// </summary>
        /// <param name="courseOfferingId">The id of the course offering to find.</param>
        /// <returns>The course offering, otherwise null. </returns>
        public Task<CourseOffering> GetCourseOfferingByIdAsync(string courseOfferingId);

        /// <summary>
        /// Updates a course offering.
        /// </summary>
        /// <param name="courseOfferingId">The id of the course offering to update in the database. </param>
        /// <param name="courseOffering">The course offering entity to overwrite with. </param>
        /// <returns>The updated course offering, otherwise the existing one if an error occurs.</returns>
        public Task<CourseOffering> UpdateCourseOfferingAsync(string courseOfferingId, CourseOffering courseOffering);

        /// <summary>
        /// Deletes a course offering.
        /// </summary>
        /// <param name="courseOfferingId">The id of the course offering to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteCourseOfferingAsync(string courseOfferingId);
    }
}
