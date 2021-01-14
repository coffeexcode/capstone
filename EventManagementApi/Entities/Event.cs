using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class Event
    {
        /// <summary>
        /// The unique id of the event
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// When the event starts
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// When the event is over
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// The unique id of the room that the event is taking place at.
        /// <see cref="Room"/>
        /// </summary>
        public string RoomId { get; set; }
    }
}
