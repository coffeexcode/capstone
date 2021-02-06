using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class CourseOfferingViewModel
    { 
        public string InstructorId { get; set; }

        public string CourseId { get; set; }

        public string TimeslotId { get; set; }

        public string RoomId { get; set; }
    }
}
