using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface ICourseService
    {
        public Task<Course> CreateCourseAsync(CourseViewModel model);

        public Task<IList<Course>> GetCoursesAsync();

        public Task<Course> GetCourseByIdAsync(string courseId);

        public Task<Course> UpdateCourseAsync(string courseId, JsonPatchDocument<CourseViewModel> patchDocument);

        public Task DeleteCourseAsync(string courseId);
    }
}
