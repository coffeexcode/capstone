using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class EventOfferingRepository : IEventOfferingRepository
    {
        private readonly EventManagementDbContext context;

        public EventOfferingRepository(EventManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<EventOffering> CreateEventOfferingAsync(EventOffering eventOffering)
        {
            var added = await context.EventOfferings.AddAsync(eventOffering);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(EventOffering), eventOffering.Id);
        }

        public async Task DeleteEventOfferingAsync(string eventOfferingId)
        {
            var toRemove = await GetEventOfferingByIdAsync(eventOfferingId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.EventOfferings.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(EventOffering), eventOfferingId);
            }
        }

        public async Task<EventOffering> GetEventOfferingByIdAsync(string eventOfferingId)
        {
            return await context.EventOfferings.AsNoTracking().FirstOrDefaultAsync(e => e.Id == eventOfferingId);
        }

        public async Task<IList<EventOffering>> GetEventOfferingsAsync()
        {
            return await context.EventOfferings.AsNoTracking().ToListAsync();
        }

        public async Task<EventOffering> UpdateEventOfferingAsync(string eventOfferingId, EventOffering eventOffering)
        {
            var toUpdate = await GetEventOfferingByIdAsync(eventOfferingId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Room), eventOfferingId);
            }

            toUpdate = eventOffering;

            var updated = context.EventOfferings.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Room), eventOfferingId);
            }

            return updated.Entity;
        }
    }
}
