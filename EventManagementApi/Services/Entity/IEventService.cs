using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface IEventService
    {
        public Task<Event> CreateEventAsync(EventViewModel model);

        public Task<IList<Event>> GetEventsAsync();

        public Task<Event> GetEventByIdAsync(string eventId);

        public Task<Event> UpdateEventAsync(string eventId, JsonPatchDocument<EventViewModel> patchDocument);

        public Task DeleteEventAsync(string eventId);
    }
}
