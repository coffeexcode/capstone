using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class EventRepository : IEventRepository
    {
        private readonly ILogger<EventRepository> logger;
        private readonly EventManagementDbContext context;

        public EventRepository(
            ILogger<EventRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Event> CreateEventAsync(Event @event)
        {
            var added = await context.Events.AddAsync(@event);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new AddEntityException(typeof(Event), @event.Id);
        }

        public async Task DeleteEventAsync(string eventId)
        {
            var toRemove = await GetEventByIdAsync(eventId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Events.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Event), eventId);
            }
        }

        public async Task<Event> GetEventByIdAsync(string eventId)
        {
            return await context.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task<IList<Event>> GetEventsAsync()
        {
            return await context.Events.AsNoTracking().ToListAsync();
        }

        public async Task<Event> UpdateEventAsync(string eventId, Event @event)
        {
            var toUpdate = await GetEventByIdAsync(eventId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Event), eventId);
            }

            toUpdate = @event;

            var updated = context.Events.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Event), eventId);
            }

            return updated.Entity;
        }
    }
}
