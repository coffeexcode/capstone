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
    /// Provides CRUD functionality for instructors.
    /// </summary>
    public interface IInstructorService
    {
        /// <summary>
        /// Creates a instructor
        /// </summary>
        /// <param name="model">The model to use to create the instructor </param>
        /// <returns>The created instructor, otherwise null. </returns>
        public Task<Instructor> CreateInstructorAsync(InstructorViewModel model);

        /// <summary>
        /// Gets all instructors.
        /// </summary>
        /// <returns>A list of all instructor. </returns>
        public Task<IList<Instructor>> GetInstructorsAsync();

        /// <summary>
        /// Gets a single instructor by its unique id.
        /// </summary>
        /// <param name="instructorId">The id of the instructor  to find.</param>
        /// <returns>The instructor, otherwise null. </returns>
        public Task<Instructor> GetInstructorByIdAsync(string instructorId);

        /// <summary>
        /// Updates a instructor
        /// </summary>
        /// <param name="instructorId">The instructor to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the instructor</param>
        /// <returns>The updated instructor, otherwise the existing one if an error occurs.</returns>
        public Task<Instructor> UpdateInstructorAsync(string instructorId, JsonPatchDocument<InstructorViewModel> patchDocument);

        /// <summary>
        /// Deletes a instructor
        /// </summary>
        /// <param name="instructorId">The id of the instructor to delete.</param>
        /// <returns></returns>
        public Task DeleteInstructorAsync(string instructorId);
    }
}
