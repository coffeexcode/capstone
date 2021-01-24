using EventManagementApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface ICourseOfferingRepository
    {
        public Task<CourseOffering> CreateCourseOfferingAsync(CourseOffering courseOffering);

        public Task<IList<CourseOffering>> GetCourseOfferingsAsync();

        public Task<CourseOffering> GetCourseOfferingByIdAsync(string courseOfferingId);

        public Task<CourseOffering> UpdateCourseOfferingAsync(string courseOfferingId, CourseOffering courseOffering);

        public Task DeleteCourseOfferingAsync(string courseOfferingId);
    }
}
