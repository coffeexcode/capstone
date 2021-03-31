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
    /// for instructors.
    /// </summary>
    public interface IInstructorRepository
    {
        /// <summary>
        /// Creates a instructor regiustration in the backing database.
        /// </summary>
        /// <param name="instructor">The instructor to create in the database. </param>
        /// <returns>The created instructor as in the database. </returns>
        public Task<Instructor> CreateInstructorAsync(Instructor instructor);

        /// <summary>
        /// Gets all instructors in the backing database.
        /// </summary>
        /// <returns>A list of all instructors registrations. </returns>
        public Task<IList<Instructor>> GetInstructorsAsync();

        /// <summary>
        /// Gets single instructor by its unique id.
        /// </summary>
        /// <param name="instructorId">The id of the instructor to find.</param>
        /// <returns>The instructor, otherwise null. </returns>
        public Task<Instructor> GetInstructorByIdAsync(string instructorId);

        /// <summary>
        /// Updates a instructor.
        /// </summary>
        /// <param name="instructorId">The id of the instructor to update in the database. </param>
        /// <param name="instructor">The instructor entity to overwrite with. </param>
        /// <returns>The updated instructor, otherwise the existing one if an error occurs.</returns>
        public Task<Instructor> UpdateInstructorAsync(string instructorId, Instructor instructor);

        /// <summary>
        /// Deletes a instructor.
        /// </summary>
        /// <param name="instructorId">The id of the instructor to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteInstructorAsync(string instructorId);
    }
}
