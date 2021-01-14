using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface ITimeslotRepository
    {
        public Task<Timeslot> CreateTimeslotAsync(Timeslot timeslot);

        public Task<IList<Timeslot>> GetTimeslotsAsync();

        public Task<Timeslot> GetTimeslotByIdAsync(string timeslotId);

        public Task<Timeslot> UpdateTimeslotAsync(string timeslotId, Timeslot timeslot);

        public Task DeleteTimeslotAsync(string timeslotId);
    }
}
