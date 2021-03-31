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
    public class CourseOfferingService : ICourseOfferingService
    {
        private readonly EventManagementDbContext context;
        private readonly ICourseOfferingRepository repository;
        private readonly IMapper mapper;

        public CourseOfferingService(EventManagementDbContext context,
            ICourseOfferingRepository repository,
            IMapper mapper)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CourseOffering> CreateCourseOfferingAsync(CourseOfferingViewModel model)
        {
            try
            {
                var courseOffering = mapper.Map<CourseOffering>(model);

                var created = await repository.CreateCourseOfferingAsync(courseOffering);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteCourseOfferingAsync(string courseOfferingId)
        {
            try
            {
                await repository.DeleteCourseOfferingAsync(courseOfferingId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CourseOffering> GetCourseOfferingByIdAsync(string courseOfferingId)
        {
            try
            {
                var courseOffering = await repository.GetCourseOfferingByIdAsync(courseOfferingId);

                return courseOffering;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<CourseOffering>> GetCourseOfferingsAsync()
        {
            try
            {
                return await repository.GetCourseOfferingsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CourseOffering> UpdateCourseOfferingAsync(string courseOfferingId, JsonPatchDocument<CourseOfferingViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetCourseOfferingByIdAsync(courseOfferingId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(CourseOffering), courseOfferingId);
                }

                // Apply patch
                var updatedModel = mapper.Map<CourseOfferingViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedCourseOffering = mapper.Map<CourseOffering>(updatedModel);
                updatedCourseOffering.Id = courseOfferingId;

                // Apply changes
                var updated = await repository.UpdateCourseOfferingAsync(courseOfferingId, updatedCourseOffering);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<CourseOffering> SaveAndReturn(CourseOffering courseOffering)
        {
            await context.SaveChangesAsync();

            return courseOffering;
        }
    }
}
