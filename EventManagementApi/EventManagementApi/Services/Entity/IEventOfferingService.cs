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
    /// Provides CRUD functionality for event offering.
    /// </summary>
    public interface IEventOfferingService
    {
        /// <summary>
        /// Creates a event offering.
        /// </summary>
        /// <param name="model">The model to use to create the event offering . </param>
        /// <returns></returns>
        public Task<EventOffering> CreateEventOfferingAsync(EventOfferingViewModel model);

        /// <summary>
        /// Gets all event offering.
        /// </summary>
        /// <returns>A list of all event offering. </returns>
        public Task<IList<EventOffering>> GetEventOfferingsAsync();

        /// <summary>
        /// Gets aingle event offering  by its unique id.
        /// </summary>
        /// <param name="eventOfferingId">The id of the event offering  to find.</param>
        /// <returns>The event offering, otherwise null. </returns>
        public Task<EventOffering> GetEventOfferingByIdAsync(string eventOfferingId);

        /// <summary>
        /// Updates a event offering.
        /// </summary>
        /// <param name="eventOfferingId">The  update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the event offering .</param>
        /// <returns>The updated event offering, otherwise the existing one if an error occurs.</returns>
        public Task<EventOffering> UpdateEventOfferingAsync(string eventOfferingId, JsonPatchDocument<EventOfferingViewModel> patchDocument);

        /// <summary>
        /// Deletes a event offering.
        /// </summary>
        /// <param name="eventOfferingId">The id of the event offering to delete.</param>
        /// <returns></returns>
        public Task DeleteEventOfferingAsync(string eventOfferingId);
    }
}
