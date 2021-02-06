using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class EventOffering
    {
        public string Id { get; set; }

        public Event Event { get; set; }

        public string EventId { get; set; }

        public Timeslot Timeslot { get; set; }

        public string TimeslotId { get; set; }

        public Room Room { get; set; }

        public string RoomId { get; set; }
    }
}
