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
    public class InstructorService : IInstructorService
    {
        private readonly ILogger<InstructorService> logger;
        private readonly EventManagementDbContext context;
        private readonly IInstructorRepository repository;
        private readonly IMapper mapper;

        public InstructorService(
            ILogger<InstructorService> logger,
            EventManagementDbContext context,
            IInstructorRepository repository,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Instructor> CreateInstructorAsync(InstructorViewModel model)
        {
            try
            {
                var instructor = mapper.Map<Instructor>(model);

                var created = await repository.CreateInstructorAsync(instructor);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteInstructorAsync(string instructorId)
        {
            try
            {
                await repository.DeleteInstructorAsync(instructorId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Instructor> GetInstructorByIdAsync(string instructorId)
        {
            try
            {
                var instructor = await repository.GetInstructorByIdAsync(instructorId);

                return instructor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Instructor>> GetInstructorsAsync()
        {
            try
            {
                return await repository.GetInstructorsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Instructor> UpdateInstructorAsync(string instructorId, JsonPatchDocument<InstructorViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetInstructorByIdAsync(instructorId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Instructor), instructorId);
                }

                // Apply patch
                var updatedModel = mapper.Map<InstructorViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedInstructor = mapper.Map<Instructor>(updatedModel);
                updatedInstructor.Id = instructorId;

                // Apply changes
                var updated = await repository.UpdateInstructorAsync(instructorId, updatedInstructor);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Instructor> SaveAndReturn(Instructor instructor)
        {
            await context.SaveChangesAsync();

            return instructor;
        }
    }
}
