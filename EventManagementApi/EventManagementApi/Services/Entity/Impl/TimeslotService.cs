using AutoMapper;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using EventManagementApi.Repositories;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity.Impl
{
    public class TimeslotService : ITimeslotService
    {
        private readonly ILogger<TimeslotService> logger;
        private readonly EventManagementDbContext context;
        private readonly ITimeslotRepository repository;
        private readonly IMapper mapper;

        public TimeslotService(
            ILogger<TimeslotService> logger,
            EventManagementDbContext context,
            ITimeslotRepository repository,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Timeslot> CreateTimeslotAsync(TimeslotViewModel model)
        {
            try
            {
                var timeslot = mapper.Map<Timeslot>(model);

                var created = await repository.CreateTimeslotAsync(timeslot);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteTimeslotAsync(string timeslotId)
        {
            try
            {
                await repository.DeleteTimeslotAsync(timeslotId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Timeslot> GetTimeslotByIdAsync(string timeslotId)
        {
            try
            {
                var timeslot = await repository.GetTimeslotByIdAsync(timeslotId);

                return timeslot;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Timeslot>> GetTimeslotsAsync()
        {
            try
            {
                return await repository.GetTimeslotsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Timeslot> UpdateTimeslotAsync(string timeslotId, JsonPatchDocument<TimeslotViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetTimeslotByIdAsync(timeslotId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Timeslot), timeslotId);
                }

                // Apply patch
                var updatedModel = mapper.Map<TimeslotViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedTimeslot = mapper.Map<Timeslot>(updatedModel);
                updatedTimeslot.Id = timeslotId;

                // Apply changes
                var updated = await repository.UpdateTimeslotAsync(timeslotId, updatedTimeslot);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Timeslot> SaveAndReturn(Timeslot timeslot)
        {
            await context.SaveChangesAsync();

            return timeslot;
        }
    }
}
