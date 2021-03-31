using EventManagementApi.Core.Data;
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
    public class TimeslotRepository : ITimeslotRepository
    {
        private readonly ILogger<TimeslotRepository> logger;
        private readonly EventManagementDbContext context;

        public TimeslotRepository(
            ILogger<TimeslotRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Timeslot> CreateTimeslotAsync(Timeslot timeslot)
        {
            var added = await context.Timeslots.AddAsync(timeslot);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(Timeslot), timeslot.Id);
        }

        public async Task DeleteTimeslotAsync(string timeslotId)
        {
            var toRemove = await GetTimeslotByIdAsync(timeslotId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Timeslots.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Timeslot), timeslotId);
            }
        }

        public async Task<Timeslot> GetTimeslotByIdAsync(string timeslotId)
        {
            return await context.Timeslots.AsNoTracking().FirstOrDefaultAsync(c => c.Id == timeslotId);
        }

        public async Task<IList<Timeslot>> GetTimeslotsAsync()
        {
            return await context.Timeslots.AsNoTracking().ToListAsync();
        }

        public async Task<Timeslot> UpdateTimeslotAsync(string timeslotId, Timeslot timeslot)
        {
            var toUpdate = await GetTimeslotByIdAsync(timeslotId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Timeslot), timeslot.Id);
            }

            toUpdate = timeslot;

            var updated = context.Timeslots.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Timeslot), timeslot.Id);
            }

            return updated.Entity;
        }
    }
}
