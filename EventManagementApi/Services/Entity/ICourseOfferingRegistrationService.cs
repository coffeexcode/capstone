using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface ICourseOfferingRegistrationService
    {
        public Task<CourseOfferingRegistration> CreateCourseOfferingRegistrationAsync(CourseOfferingRegistrationViewModel model);

        public Task<IList<CourseOfferingRegistration>> GetCourseOfferingRegistrationsAsync();

        public Task<CourseOfferingRegistration> GetCourseOfferingRegistrationByIdAsync(string courseOfferingRegistrationId);

        public Task<CourseOfferingRegistration> UpdateCourseOfferingRegistrationAsync(string courseOfferingRegistrationId, JsonPatchDocument<CourseOfferingRegistrationViewModel> patchDocument);

        public Task DeleteCourseOfferingRegistrationAsync(string courseOfferingRegistrationId);
    }
}
