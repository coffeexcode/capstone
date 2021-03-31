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
    /// for events.
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// Creates a event regiustration in the backing database.
        /// </summary>
        /// <param name="event">The event to create in the database. </param>
        /// <returns>The created event as in the database. </returns>
        public Task<Event> CreateEventAsync(Event @event);

        /// <summary>
        /// Gets all events in the backing database.
        /// </summary>
        /// <returns>A list of all events registrations. </returns>
        public Task<IList<Event>> GetEventsAsync();

        /// <summary>
        /// Gets single event by its unique id.
        /// </summary>
        /// <param name="eventId">The id of the event to find.</param>
        /// <returns>The event, otherwise null. </returns>
        public Task<Event> GetEventByIdAsync(string eventId);

        /// <summary>
        /// Updates a event.
        /// </summary>
        /// <param name="eventId">The id of the event to update in the database. </param>
        /// <param name="event">The event entity to overwrite with. </param>
        /// <returns>The updated event, otherwise the existing one if an error occurs.</returns>
        public Task<Event> UpdateEventAsync(string eventId, Event @event);

        /// <summary>
        /// Deletes a event.
        /// </summary>
        /// <param name="eventId">The id of the event to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteEventAsync(string eventId);
    }
}
