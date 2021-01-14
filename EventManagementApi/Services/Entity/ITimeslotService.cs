using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface ITimeslotService
    {
        public Task<Timeslot> CreateTimeslotAsync(TimeslotViewModel model);

        public Task<IList<Timeslot>> GetTimeslotsAsync();

        public Task<Timeslot> GetTimeslotByIdAsync(string timeslotId);

        public Task<Timeslot> UpdateTimeslotAsync(string timeslotId, JsonPatchDocument<TimeslotViewModel> patchDocument);

        public Task DeleteTimeslotAsync(string timeslotId);
    }
}
