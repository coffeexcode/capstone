using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class CourseOfferingRegistrationRepository : ICourseOfferingRegistrationRepository
    {
        private readonly EventManagementDbContext context;

        public CourseOfferingRegistrationRepository(EventManagementDbContext context)
        {
            this.context = context;
        }
        public async Task<CourseOfferingRegistration> CreateCourseOfferingRegistrationAsync(CourseOfferingRegistration courseOfferingRegistration)
        {
            var added = await context.CourseOfferingRegistrations.AddAsync(courseOfferingRegistration);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(CourseOfferingRegistration), courseOfferingRegistration.Id);
        }

        public async Task DeleteCourseOfferingRegistrationAsync(string courseOfferingRegistrationId)
        {
            var toRemove = await GetCourseOfferingRegistrationByIdAsync(courseOfferingRegistrationId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.CourseOfferingRegistrations.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(CourseOfferingRegistration), courseOfferingRegistrationId);
            }
        }

        public async Task<CourseOfferingRegistration> GetCourseOfferingRegistrationByIdAsync(string courseOfferingRegistrationId)
        {
            return await context.CourseOfferingRegistrations
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == courseOfferingRegistrationId);
        }

        public async Task<IList<CourseOfferingRegistration>> GetCourseOfferingRegistrationsAsync()
        {
            return await context.CourseOfferingRegistrations.AsNoTracking().ToListAsync();
        }

        public async Task<CourseOfferingRegistration> UpdateCourseOfferingRegistrationAsync(string courseOfferingRegistrationId, CourseOfferingRegistration courseOfferingRegistration)
        {
            var toUpdate = await GetCourseOfferingRegistrationByIdAsync(courseOfferingRegistrationId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(CourseOfferingRegistration), courseOfferingRegistrationId);
            }

            toUpdate = courseOfferingRegistration;

            var updated = context.CourseOfferingRegistrations.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(CourseOffering), courseOfferingRegistrationId);
            }

            return updated.Entity;
        }
    }
}
