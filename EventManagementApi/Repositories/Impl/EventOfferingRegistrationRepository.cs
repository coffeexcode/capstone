using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class EventOfferingRegistrationRepository : IEventOfferingRegistrationRepository
    {
        private readonly EventManagementDbContext context;

        public EventOfferingRegistrationRepository(EventManagementDbContext context)
        {
            this.context = context;
        }
        public async Task<EventOfferingRegistration> CreateEventOfferingRegistrationAsync(EventOfferingRegistration eventOfferingRegistration)
        {
            var added = await context.EventOfferingRegistrations.AddAsync(eventOfferingRegistration);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(EventOfferingRegistration), eventOfferingRegistration.Id);
        }

        public async Task DeleteEventOfferingRegistrationAsync(string eventOfferingRegistrationId)
        {
            var toRemove = await GetEventOfferingRegistrationByIdAsync(eventOfferingRegistrationId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.EventOfferingRegistrations.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(EventOfferingRegistration), eventOfferingRegistrationId);
            }
        }

        public async Task<EventOfferingRegistration> GetEventOfferingRegistrationByIdAsync(string eventOfferingRegistrationId)
        {
            return await context.EventOfferingRegistrations
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == eventOfferingRegistrationId);
        }

        public async Task<IList<EventOfferingRegistration>> GetEventOfferingRegistrationsAsync()
        {
            return await context.EventOfferingRegistrations.AsNoTracking().ToListAsync();
        }

        public async Task<EventOfferingRegistration> UpdateEventOfferingRegistrationAsync(string eventOfferingRegistrationId, EventOfferingRegistration eventOfferingRegistration)
        {
            var toUpdate = await GetEventOfferingRegistrationByIdAsync(eventOfferingRegistrationId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(EventOfferingRegistration), eventOfferingRegistrationId);
            }

            toUpdate = eventOfferingRegistration;

            var updated = context.EventOfferingRegistrations.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(CourseOffering), eventOfferingRegistrationId);
            }

            return updated.Entity;
        }
    }
}
