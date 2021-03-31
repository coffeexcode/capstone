using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    /// <summary>
    /// Provides CRUD functionality for course offering.
    /// </summary>
    public interface ICourseOfferingService
    {
        /// <summary>
        /// Creates a course offering.
        /// </summary>
        /// <param name="model">The model to use to create the course offering . </param>
        /// <returns></returns>
        public Task<CourseOffering> CreateCourseOfferingAsync(CourseOfferingViewModel model);

        /// <summary>
        /// Gets all course offering.
        /// </summary>
        /// <returns>A list of all course offering. </returns>
        public Task<IList<CourseOffering>> GetCourseOfferingsAsync();

        /// <summary>
        /// Gets aingle course offering  by its unique id.
        /// </summary>
        /// <param name="courseOfferingId">The id of the course offering  to find.</param>
        /// <returns>The course offering, otherwise null. </returns>
        public Task<CourseOffering> GetCourseOfferingByIdAsync(string courseOfferingId);

        /// <summary>
        /// Updates a course offering.
        /// </summary>
        /// <param name="courseOfferingId">The course offering to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the course offering .</param>
        /// <returns>The updated course offering, otherwise the existing one if an error occurs.</returns>
        public Task<CourseOffering> UpdateCourseOfferingAsync(string courseOfferingId, JsonPatchDocument<CourseOfferingViewModel> patchDocument);

        /// <summary>
        /// Deletes a course offering.
        /// </summary>
        /// <param name="courseOfferingId">The id of the course offering to delete.</param>
        /// <returns></returns>
        public Task DeleteCourseOfferingAsync(string courseOfferingId);
    }
}
