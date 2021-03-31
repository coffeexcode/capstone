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
    /// Provides CRUD functionality for events.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Creates a event
        /// </summary>
        /// <param name="model">The model to use to create the event </param>
        /// <returns>The created event, otherwise null. </returns>
        public Task<Event> CreateEventAsync(EventViewModel model);

        /// <summary>
        /// Gets all event.
        /// </summary>
        /// <returns>A list of all event. </returns>
        public Task<IList<Event>> GetEventsAsync();

        /// <summary>
        /// Gets a single event by its unique id.
        /// </summary>
        /// <param name="eventId">The id of the event  to find.</param>
        /// <returns>The event, otherwise null. </returns>
        public Task<Event> GetEventByIdAsync(string eventId);

        /// <summary>
        /// Updates a event
        /// </summary>
        /// <param name="eventId">The event to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the event</param>
        /// <returns>The updated event, otherwise the existing one if an error occurs.</returns>
        public Task<Event> UpdateEventAsync(string eventId, JsonPatchDocument<EventViewModel> patchDocument);

        /// <summary>
        /// Deletes a event
        /// </summary>
        /// <param name="eventId">The id of the event to delete.</param>
        /// <returns></returns>
        public Task DeleteEventAsync(string eventId);
    }
}
