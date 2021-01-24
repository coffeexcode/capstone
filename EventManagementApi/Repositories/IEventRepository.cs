using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface IEventRepository
    {
        public Task<Event> CreateEventAsync(Event @event);

        public Task<IList<Event>> GetEventsAsync();

        public Task<Event> GetEventByIdAsync(string eventId);

        public Task<Event> UpdateEventAsync(string eventId, Event @event);

        public Task DeleteEventAsync(string eventId);
    }
}
