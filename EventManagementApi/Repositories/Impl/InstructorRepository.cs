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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ILogger<InstructorRepository> logger;
        private readonly EventManagementDbContext context;

        public InstructorRepository(
            ILogger<InstructorRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Instructor> CreateInstructorAsync(Instructor instructor)
        {
            var added = await context.Instructors.AddAsync(instructor);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(Instructor), instructor.Id);
        }

        public async Task DeleteInstructorAsync(string instructorId)
        {
            var toRemove = await GetInstructorByIdAsync(instructorId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Instructors.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Instructor), instructorId);
            }
        }

        public async Task<Instructor> GetInstructorByIdAsync(string instructorId)
        {
            return await context.Instructors.AsNoTracking().FirstOrDefaultAsync(c => c.Id == instructorId);
        }

        public async Task<IList<Instructor>> GetInstructorsAsync()
        {
            return await context.Instructors.AsNoTracking().ToListAsync();
        }

        public async Task<Instructor> UpdateInstructorAsync(string instructorId, Instructor instructor)
        {
            var toUpdate = await GetInstructorByIdAsync(instructorId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Instructor), instructor.Id);
            }

            toUpdate = instructor;

            var updated = context.Instructors.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Instructor), instructor.Id);
                
            }

            return updated.Entity;
        }
    }
}
