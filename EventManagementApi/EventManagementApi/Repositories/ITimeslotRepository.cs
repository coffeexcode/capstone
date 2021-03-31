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
    /// for timeslots.
    /// </summary>
    public interface ITimeslotRepository
    {
        /// <summary>
        /// Creates a timeslot regiustration in the backing database.
        /// </summary>
        /// <param name="timeslot">The timeslot to create in the database. </param>
        /// <returns>The created timeslot as in the database. </returns>
        public Task<Timeslot> CreateTimeslotAsync(Timeslot timeslot);

        /// <summary>
        /// Gets all timeslots in the backing database.
        /// </summary>
        /// <returns>A list of all timeslots registrations. </returns>
        public Task<IList<Timeslot>> GetTimeslotsAsync();

        /// <summary>
        /// Gets single timeslot by its unique id.
        /// </summary>
        /// <param name="timeslotId">The id of the timeslot to find.</param>
        /// <returns>The timeslot, otherwise null. </returns>
        public Task<Timeslot> GetTimeslotByIdAsync(string timeslotId);

        /// <summary>
        /// Updates a timeslot.
        /// </summary>
        /// <param name="timeslotId">The id of the timeslot to update in the database. </param>
        /// <param name="timeslot">The timeslot entity to overwrite with. </param>
        /// <returns>The updated timeslot, otherwise the existing one if an error occurs.</returns>
        public Task<Timeslot> UpdateTimeslotAsync(string timeslotId, Timeslot timeslot);

        /// <summary>
        /// Deletes a timeslot.
        /// </summary>
        /// <param name="timeslotId">The id of the timeslot to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteTimeslotAsync(string timeslotId);
    }
}
