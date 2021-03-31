using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for event offerings.
    /// </summary>
    public interface IEventOfferingRepository
    {
        /// <summary>
        /// Creates a event offering regiustration in the backing database.
        /// </summary>
        /// <param name="eventOffering">The event offering to create in the database. </param>
        /// <returns>The created event offering as in the database. </returns>
        public Task<EventOffering> CreateEventOfferingAsync(EventOffering eventOffering);

        /// <summary>
        /// Gets all event offerings in the backing database.
        /// </summary>
        /// <returns>A list of all event offerings registrations. </returns>
        public Task<IList<EventOffering>> GetEventOfferingsAsync();

        /// <summary>
        /// Gets single event offering by its unique id.
        /// </summary>
        /// <param name="eventOfferingId">The id of the event offering to find.</param>
        /// <returns>The event offering, otherwise null. </returns>
        public Task<EventOffering> GetEventOfferingByIdAsync(string eventOfferingId);

        /// <summary>
        /// Updates a event offering.
        /// </summary>
        /// <param name="eventOfferingId">The id of the event offering to update in the database. </param>
        /// <param name="eventOffering">The event offering entity to overwrite with. </param>
        /// <returns>The updated event offering, otherwise the existing one if an error occurs.</returns>
        public Task<EventOffering> UpdateEventOfferingAsync(string eventOfferingId, EventOffering eventOffering);

        /// <summary>
        /// Deletes a event offering.
        /// </summary>
        /// <param name="eventOfferingId">The id of the event offering to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteEventOfferingAsync(string eventOfferingId);
    }
}
