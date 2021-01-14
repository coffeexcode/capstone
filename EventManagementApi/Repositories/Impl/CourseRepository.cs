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
    public class CourseRepository : ICourseRepository
    {
        private readonly ILogger<CourseRepository> logger;
        private readonly EventManagementDbContext context;

        public CourseRepository(
            ILogger<CourseRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            var added = await context.Courses.AddAsync(course);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new AddEntityException(typeof(Course), course.Id);
        }

        public async Task DeleteCourseAsync(string courseId)
        {
            var toRemove = await GetCourseByIdAsync(courseId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Courses.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Course), courseId);
            }
        }

        public async Task<Course> GetCourseByIdAsync(string courseId)
        {
            return await context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<IList<Course>> GetCoursesAsync()
        {
            return await context.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Course> UpdateCourseAsync(string courseId, Course course)
        {
            var toUpdate = await GetCourseByIdAsync(courseId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Course), courseId);
            }

            toUpdate = course;

            var updated = context.Courses.Update(toUpdate);
            
            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Course), courseId);
            }

            return updated.Entity;
        }
    }
}
