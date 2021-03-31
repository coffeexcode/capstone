using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for course offering registrations.
    /// </summary>
    public interface ICourseOfferingRegistrationRepository
    {
        /// <summary>
        /// Creates a course offering regiustration in the backing database.
        /// </summary>
        /// <param name="courseOfferingRegistration">The course offering registration to create in the database. </param>
        /// <returns>The created course offering registration as in the database. </returns>
        public Task<CourseOfferingRegistration> CreateCourseOfferingRegistrationAsync(CourseOfferingRegistration courseOfferingRegistration);

        /// <summary>
        /// Gets all course offering registrations in the backing database.
        /// </summary>
        /// <returns>A list of all course offerings registrations. </returns>
        public Task<IList<CourseOfferingRegistration>> GetCourseOfferingRegistrationsAsync();

        /// <summary>
        /// Gets single course offering by its unique id.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The id of the course offering registration to find.</param>
        /// <returns>The course offering registration, otherwise null. </returns>
        public Task<CourseOfferingRegistration> GetCourseOfferingRegistrationByIdAsync(string courseOfferingRegistrationId);

        /// <summary>
        /// Updates a course offering.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The id of the course offering registration to update in the database. </param>
        /// <param name="courseOfferingRegistration">The course offering entity to overwrite with. </param>
        /// <returns>The updated course offering registration, otherwise the existing one if an error occurs.</returns>
        public Task<CourseOfferingRegistration> UpdateCourseOfferingRegistrationAsync(string courseOfferingRegistrationId, CourseOfferingRegistration courseOfferingRegistration);

        /// <summary>
        /// Deletes a course offering registration.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The id of the course offering to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteCourseOfferingRegistrationAsync(string courseOfferingRegistrationId);
    }
}
