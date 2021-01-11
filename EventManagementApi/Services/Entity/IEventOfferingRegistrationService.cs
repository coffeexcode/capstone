using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface IEventOfferingRegistrationService
    {
        public Task<EventOfferingRegistration> CreateEventOfferingRegistrationAsync(EventOfferingRegistrationViewModel model);

        public Task<IList<EventOfferingRegistration>> GetEventOfferingRegistrationsAsync();

        public Task<EventOfferingRegistration> GetEventOfferingRegistrationByIdAsync(string eventOfferingRegistrationId);

        public Task<EventOfferingRegistration> UpdateEventOfferingRegistrationAsync(string eventOfferingRegistrationId, JsonPatchDocument<EventOfferingRegistrationViewModel> patchDocument);

        public Task DeleteEventOfferingRegistrationAsync(string eventOfferingRegistrationId);
    }
}
