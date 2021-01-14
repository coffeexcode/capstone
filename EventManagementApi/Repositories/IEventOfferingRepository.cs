using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface IEventOfferingRepository
    {
        public Task<EventOffering> CreateEventOfferingAsync(EventOffering eventOffering);

        public Task<IList<EventOffering>> GetEventOfferingsAsync();

        public Task<EventOffering> GetEventOfferingByIdAsync(string eventOfferingId);

        public Task<EventOffering> UpdateEventOfferingAsync(string eventOfferingId, EventOffering eventOffering);

        public Task DeleteEventOfferingAsync(string eventOfferingId);
    }
}
