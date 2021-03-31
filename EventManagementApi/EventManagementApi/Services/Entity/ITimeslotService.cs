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
    /// Provides CRUD functionality for timeslots.
    /// </summary>
    public interface ITimeslotService
    {
        /// <summary>
        /// Creates a timeslot
        /// </summary>
        /// <param name="model">The model to use to create the timeslot </param>
        /// <returns>The created timeslot, otherwise null. </returns>
        public Task<Timeslot> CreateTimeslotAsync(TimeslotViewModel model);

        /// <summary>
        /// Gets all timeslot.
        /// </summary>
        /// <returns>A list of all timeslot. </returns>
        public Task<IList<Timeslot>> GetTimeslotsAsync();

        /// <summary>
        /// Gets a single timeslot by its unique id.
        /// </summary>
        /// <param name="timeslotId">The id of the timeslot  to find.</param>
        /// <returns>The timeslot, otherwise null. </returns>
        public Task<Timeslot> GetTimeslotByIdAsync(string timeslotId);

        /// <summary>
        /// Updates a timeslot
        /// </summary>
        /// <param name="timeslotId">The timeslot to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the timeslot</param>
        /// <returns>The updated timeslot, otherwise the existing one if an error occurs.</returns>
        public Task<Timeslot> UpdateTimeslotAsync(string timeslotId, JsonPatchDocument<TimeslotViewModel> patchDocument);

        /// <summary>
        /// Deletes a timeslot
        /// </summary>
        /// <param name="timeslotId">The id of the timeslot to delete.</param>
        /// <returns></returns>
        public Task DeleteTimeslotAsync(string timeslotId);
    }
}
