using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface ICourseOfferingService
    {
        public Task<CourseOffering> CreateCourseOfferingAsync(CourseOfferingViewModel model);

        public Task<IList<CourseOffering>> GetCourseOfferingsAsync();

        public Task<CourseOffering> GetCourseOfferingByIdAsync(string courseOfferingId);

        public Task<CourseOffering> UpdateCourseOfferingAsync(string courseOfferingId, JsonPatchDocument<CourseOfferingViewModel> patchDocument);

        public Task DeleteCourseOfferingAsync(string courseOfferingId);
    }
}
