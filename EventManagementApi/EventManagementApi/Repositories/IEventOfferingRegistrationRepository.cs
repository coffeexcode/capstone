using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for event offering registrations.
    /// </summary>
    public interface IEventOfferingRegistrationRepository
    {
        /// <summary>
        /// Creates a event offering regiustration in the backing database.
        /// </summary>
        /// <param name="eventOfferingRegistration">The event offering registration to create in the database. </param>
        /// <returns>The created event offering registration as in the database. </returns>
        public Task<EventOfferingRegistration> CreateEventOfferingRegistrationAsync(EventOfferingRegistration eventOfferingRegistration);

        /// <summary>
        /// Gets all event offering registrations in the backing database.
        /// </summary>
        /// <returns>A list of all event offerings registrations. </returns>
        public Task<IList<EventOfferingRegistration>> GetEventOfferingRegistrationsAsync();

        /// <summary>
        /// Gets single event offering by its unique id.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The id of the event offering registration to find.</param>
        /// <returns>The event offering registration, otherwise null. </returns>
        public Task<EventOfferingRegistration> GetEventOfferingRegistrationByIdAsync(string eventOfferingRegistrationId);

        /// <summary>
        /// Updates a event offering.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The id of the event offering registration to update in the database. </param>
        /// <param name="eventOfferingRegistration">The event offering entity to overwrite with. </param>
        /// <returns>The updated event offering registration, otherwise the existing one if an error occurs.</returns>
        public Task<EventOfferingRegistration> UpdateEventOfferingRegistrationAsync(string eventOfferingRegistrationId, EventOfferingRegistration eventOfferingRegistration);

        /// <summary>
        /// Deletes a event offering registration.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The id of the event offering to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteEventOfferingRegistrationAsync(string eventOfferingRegistrationId);
    }
}
