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
    /// Provides CRUD functionality for course offering registrations.
    /// </summary>
    public interface ICourseOfferingRegistrationService
    {
        /// <summary>
        /// Creates a course offering registration.
        /// </summary>
        /// <param name="model">The model to use to create the course offering registration. </param>
        /// <returns></returns>
        public Task<CourseOfferingRegistration> CreateCourseOfferingRegistrationAsync(CourseOfferingRegistrationViewModel model);

        /// <summary>
        /// Gets all course offering registrations.
        /// </summary>
        /// <returns>A list of all course offering registrations. </returns>
        public Task<IList<CourseOfferingRegistration>> GetCourseOfferingRegistrationsAsync();

        /// <summary>
        /// Gets a single course offering registration by its unique id.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The id of the course offering registration to find.</param>
        /// <returns>The course offering registration, otherwise null. </returns>
        public Task<CourseOfferingRegistration> GetCourseOfferingRegistrationByIdAsync(string courseOfferingRegistrationId);

        /// <summary>
        /// Updates a course offering registration.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The registration update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the course offering registration.</param>
        /// <returns>The updated course offering registration, otherwise the existing one if an error occurs.</returns>
        public Task<CourseOfferingRegistration> UpdateCourseOfferingRegistrationAsync(string courseOfferingRegistrationId, JsonPatchDocument<CourseOfferingRegistrationViewModel> patchDocument);

        /// <summary>
        /// Deletes a course offering registration.
        /// </summary>
        /// <param name="courseOfferingRegistrationId">The id of the course offering registration to delete.</param>
        /// <returns></returns>
        public Task DeleteCourseOfferingRegistrationAsync(string courseOfferingRegistrationId);
    }
}
