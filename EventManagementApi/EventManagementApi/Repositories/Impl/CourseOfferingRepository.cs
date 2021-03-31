using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class CourseOfferingRepository : ICourseOfferingRepository
    {
        private readonly EventManagementDbContext context;

        public CourseOfferingRepository(EventManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<CourseOffering> CreateCourseOfferingAsync(CourseOffering courseOffering)
        {
            var added = await context.CourseOfferings.AddAsync(courseOffering);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(CourseOffering), courseOffering.Id);
        }

        public async Task DeleteCourseOfferingAsync(string courseOfferingId)
        {
            var toRemove = await GetCourseOfferingByIdAsync(courseOfferingId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.CourseOfferings.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(CourseOffering), courseOfferingId);
            }
        }

        public async Task<CourseOffering> GetCourseOfferingByIdAsync(string courseOfferingId)
        {
            return await context.CourseOfferings
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == courseOfferingId);
        }

        public async Task<IList<CourseOffering>> GetCourseOfferingsAsync()
        {
            return await context.CourseOfferings.AsNoTracking().ToListAsync();
        }

        public async Task<CourseOffering> UpdateCourseOfferingAsync(string courseOfferingId, CourseOffering courseOffering)
        {
            var toUpdate = await GetCourseOfferingByIdAsync(courseOfferingId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(CourseOffering), courseOfferingId);
            }

            toUpdate = courseOffering;

            var updated = context.CourseOfferings.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(CourseOffering), courseOfferingId);
            }

            return updated.Entity;
        }
    }
}
