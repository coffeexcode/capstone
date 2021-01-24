using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface IEventOfferingRegistrationRepository
    {
        public Task<EventOfferingRegistration> CreateEventOfferingRegistrationAsync(EventOfferingRegistration eventOfferingRegistration);

        public Task<IList<EventOfferingRegistration>> GetEventOfferingRegistrationsAsync();

        public Task<EventOfferingRegistration> GetEventOfferingRegistrationByIdAsync(string eventOfferingRegistrationId);

        public Task<EventOfferingRegistration> UpdateEventOfferingRegistrationAsync(string eventOfferingRegistrationId, EventOfferingRegistration eventOfferingRegistration);

        public Task DeleteEventOfferingRegistrationAsync(string eventOfferingRegistrationId);
    }
}
