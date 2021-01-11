using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class CourseOffering
    {
        public string Id { get; set; }

        public Instructor Instructor { get; set; }

        public string InstructorId { get; set; }

        public Course Course { get; set; }

        public string CourseId { get; set; }

        public Timeslot Timeslot { get; set; }

        public string TimeslotId { get; set; }

        public Room Room { get; set; }

        public string RoomId { get; set; }
    }
}
