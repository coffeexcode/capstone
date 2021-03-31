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
    /// Provides CRUD functionality for event offering registrations.
    /// </summary>
    public interface IEventOfferingRegistrationService
    {
        /// <summary>
        /// Creates a event offering registration.
        /// </summary>
        /// <param name="model">The model to use to create the event offering registration. </param>
        /// <returns></returns>
        public Task<EventOfferingRegistration> CreateEventOfferingRegistrationAsync(EventOfferingRegistrationViewModel model);

        /// <summary>
        /// Gets all event offering registrations.
        /// </summary>
        /// <returns>A list of all event offering registrations. </returns>
        public Task<IList<EventOfferingRegistration>> GetEventOfferingRegistrationsAsync();

        /// <summary>
        /// Gets a single event offering registration by its unique id.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The id of the event offering registration to find.</param>
        /// <returns>The event offering registration, otherwise null. </returns>
        public Task<EventOfferingRegistration> GetEventOfferingRegistrationByIdAsync(string eventOfferingRegistrationId);

        /// <summary>
        /// Updates a event offering registration.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The registration update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the event offering registration.</param>
        /// <returns>The updated event offering registration, otherwise the existing one if an error occurs.</returns>
        public Task<EventOfferingRegistration> UpdateEventOfferingRegistrationAsync(string eventOfferingRegistrationId, JsonPatchDocument<EventOfferingRegistrationViewModel> patchDocument);

        /// <summary>
        /// Deletes a event offering registration.
        /// </summary>
        /// <param name="eventOfferingRegistrationId">The id of the event offering registration to delete.</param>
        /// <returns></returns>
        public Task DeleteEventOfferingRegistrationAsync(string eventOfferingRegistrationId);
    }
}
