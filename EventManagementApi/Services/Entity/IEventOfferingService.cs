using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface IEventOfferingService
    {
        public Task<EventOffering> CreateEventOfferingAsync(EventOfferingViewModel model);

        public Task<IList<EventOffering>> GetEventOfferingsAsync();

        public Task<EventOffering> GetEventOfferingByIdAsync(string eventOfferingId);

        public Task<EventOffering> UpdateEventOfferingAsync(string eventOfferingId, JsonPatchDocument<EventOfferingViewModel> patchDocument);

        public Task DeleteEventOfferingAsync(string eventOfferingId);
    }
}
