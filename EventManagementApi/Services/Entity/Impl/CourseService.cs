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
    public class CourseService : ICourseService
    {
        private readonly ILogger<CourseService> logger;
        private readonly EventManagementDbContext context;
        private readonly ICourseRepository repository;
        private readonly IMapper mapper;

        public CourseService(
            ILogger<CourseService> logger,
            EventManagementDbContext context,
            ICourseRepository repository,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Course> CreateCourseAsync(CourseViewModel model)
        {
            try
            {
                var course = mapper.Map<Course>(model);

                var created = await repository.CreateCourseAsync(course);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteCourseAsync(string courseId)
        {
            try
            {
                await repository.DeleteCourseAsync(courseId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Course> GetCourseByIdAsync(string courseId)
        {
            try
            {
                var course = await repository.GetCourseByIdAsync(courseId);

                return course;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Course>> GetCoursesAsync()
        {
            try
            {
                return await repository.GetCoursesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Course> UpdateCourseAsync(string courseId, JsonPatchDocument<CourseViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetCourseByIdAsync(courseId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Course), courseId);
                }

                // Apply patch
                var updatedModel = mapper.Map<CourseViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedCourse = mapper.Map<Course>(updatedModel);
                updatedCourse.Id = courseId;

                // Apply changes
                var updated = await repository.UpdateCourseAsync(courseId, updatedCourse);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Course> SaveAndReturn(Course course)
        {
            await context.SaveChangesAsync();

            return course;
        }
    }
}
