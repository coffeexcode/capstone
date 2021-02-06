using AutoMapper;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using EventManagementApi.Repositories;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity.Impl
{
    public class EventOfferingService : IEventOfferingService
    {
        private readonly EventManagementDbContext context;
        private readonly IEventOfferingRepository repository;
        private readonly IMapper mapper;

        public EventOfferingService(EventManagementDbContext context,
            IEventOfferingRepository repository,
            IMapper mapper)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<EventOffering> CreateEventOfferingAsync(EventOfferingViewModel model)
        {
            try
            {
                var eventOffering = mapper.Map<EventOffering>(model);

                var created = await repository.CreateEventOfferingAsync(eventOffering);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteEventOfferingAsync(string eventOfferingId)
        {
            try
            {
                await repository.DeleteEventOfferingAsync(eventOfferingId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EventOffering> GetEventOfferingByIdAsync(string eventOfferingId)
        {
            try
            {
                var eventOffering = await repository.GetEventOfferingByIdAsync(eventOfferingId);

                return eventOffering;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<EventOffering>> GetEventOfferingsAsync()
        {
            try
            {
                return await repository.GetEventOfferingsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EventOffering> UpdateEventOfferingAsync(string eventOfferingId, JsonPatchDocument<EventOfferingViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetEventOfferingByIdAsync(eventOfferingId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(EventOffering), eventOfferingId);
                }

                // Apply patch
                var updatedModel = mapper.Map<EventOfferingViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedEventOffering = mapper.Map<EventOffering>(updatedModel);
                updatedEventOffering.Id = eventOfferingId;

                // Apply changes
                var updated = await repository.UpdateEventOfferingAsync(eventOfferingId, updatedEventOffering);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<EventOffering> SaveAndReturn(EventOffering eventOffering)
        {
            await context.SaveChangesAsync();

            return eventOffering;
        }
    }
}
