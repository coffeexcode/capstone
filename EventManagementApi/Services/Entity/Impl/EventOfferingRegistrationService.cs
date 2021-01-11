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
    public class EventOfferingRegistrationService : IEventOfferingRegistrationService
    {
        private readonly EventManagementDbContext context;
        private readonly IEventOfferingRegistrationRepository repository;
        private readonly IMapper mapper;

        public EventOfferingRegistrationService(EventManagementDbContext context,
            IEventOfferingRegistrationRepository repository,
            IMapper mapper)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<EventOfferingRegistration> CreateEventOfferingRegistrationAsync(EventOfferingRegistrationViewModel model)
        {
            try
            {
                var eventOfferingRegistration = mapper.Map<EventOfferingRegistration>(model);

                var created = await repository.CreateEventOfferingRegistrationAsync(eventOfferingRegistration);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteEventOfferingRegistrationAsync(string eventOfferingRegistrationId)
        {
            try
            {
                await repository.DeleteEventOfferingRegistrationAsync(eventOfferingRegistrationId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EventOfferingRegistration> GetEventOfferingRegistrationByIdAsync(string eventOfferingRegistrationId)
        {
            try
            {
                var courseOffering = await repository.GetEventOfferingRegistrationByIdAsync(eventOfferingRegistrationId);

                return courseOffering;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<EventOfferingRegistration>> GetEventOfferingRegistrationsAsync()
        {
            try
            {
                return await repository.GetEventOfferingRegistrationsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EventOfferingRegistration> UpdateEventOfferingRegistrationAsync(string eventOfferingRegistrationId, JsonPatchDocument<EventOfferingRegistrationViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetEventOfferingRegistrationByIdAsync(eventOfferingRegistrationId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(EventOfferingRegistration), eventOfferingRegistrationId);
                }

                // Apply patch
                var updatedModel = mapper.Map<EventOfferingRegistrationViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedCourseOffering = mapper.Map<EventOfferingRegistration>(updatedModel);
                updatedCourseOffering.Id = eventOfferingRegistrationId;

                // Apply changes
                var updated = await repository.UpdateEventOfferingRegistrationAsync(eventOfferingRegistrationId, updatedCourseOffering);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<EventOfferingRegistration> SaveAndReturn(EventOfferingRegistration eventOfferingRegistration)
        {
            await context.SaveChangesAsync();

            return eventOfferingRegistration;
        }
    }
}
