using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface ICourseOfferingRegistrationRepository
    {
        public Task<CourseOfferingRegistration> CreateCourseOfferingRegistrationAsync(CourseOfferingRegistration courseOfferingRegistration);

        public Task<IList<CourseOfferingRegistration>> GetCourseOfferingRegistrationsAsync();

        public Task<CourseOfferingRegistration> GetCourseOfferingRegistrationByIdAsync(string courseOfferingRegistrationId);

        public Task<CourseOfferingRegistration> UpdateCourseOfferingRegistrationAsync(string courseOfferingRegistrationId, CourseOfferingRegistration courseOfferingRegistration);

        public Task DeleteCourseOfferingRegistrationAsync(string courseOfferingRegistrationId);
    }
}
