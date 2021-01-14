using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface ICourseRepository
    {
        public Task<Course> CreateCourseAsync(Course course);

        public Task<IList<Course>> GetCoursesAsync();

        public Task<Course> GetCourseByIdAsync(string courseId);

        public Task<Course> UpdateCourseAsync(string courseId, Course course);

        public Task DeleteCourseAsync(string courseId);
    }
}
