using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class CourseOfferingRegistration
    {
        public string Id { get; set; }

        public CourseOffering CourseOffering { get; set; }

        public string CourseOfferingId { get; set; }

        public string UserId { get; set; }
    }
}
