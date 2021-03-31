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
    public class CourseOfferingRegistrationService : ICourseOfferingRegistrationService
    {
        private readonly EventManagementDbContext context;
        private readonly ICourseOfferingRegistrationRepository repository;
        private readonly IMapper mapper;

        public CourseOfferingRegistrationService(EventManagementDbContext context,
            ICourseOfferingRegistrationRepository repository,
            IMapper mapper)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CourseOfferingRegistration> CreateCourseOfferingRegistrationAsync(CourseOfferingRegistrationViewModel model)
        {
            try
            {
                var courseOfferingRegistration = mapper.Map<CourseOfferingRegistration>(model);

                var created = await repository.CreateCourseOfferingRegistrationAsync(courseOfferingRegistration);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteCourseOfferingRegistrationAsync(string courseOfferingRegistrationId)
        {
            try
            {
                await repository.DeleteCourseOfferingRegistrationAsync(courseOfferingRegistrationId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CourseOfferingRegistration> GetCourseOfferingRegistrationByIdAsync(string courseOfferingRegistrationId)
        {
            try
            {
                var courseOffering = await repository.GetCourseOfferingRegistrationByIdAsync(courseOfferingRegistrationId);

                return courseOffering;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<CourseOfferingRegistration>> GetCourseOfferingRegistrationsAsync()
        {
            try
            {
                return await repository.GetCourseOfferingRegistrationsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CourseOfferingRegistration> UpdateCourseOfferingRegistrationAsync(string courseOfferingRegistrationId, JsonPatchDocument<CourseOfferingRegistrationViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetCourseOfferingRegistrationByIdAsync(courseOfferingRegistrationId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(CourseOfferingRegistration), courseOfferingRegistrationId);
                }

                // Apply patch
                var updatedModel = mapper.Map<CourseOfferingRegistrationViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedCourseOffering = mapper.Map<CourseOfferingRegistration>(updatedModel);
                updatedCourseOffering.Id = courseOfferingRegistrationId;

                // Apply changes
                var updated = await repository.UpdateCourseOfferingRegistrationAsync(courseOfferingRegistrationId, updatedCourseOffering);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<CourseOfferingRegistration> SaveAndReturn(CourseOfferingRegistration courseOfferingRegistration)
        {
            await context.SaveChangesAsync();

            return courseOfferingRegistration;
        }
    }
}
