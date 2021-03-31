using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class Room
    {
        /// <summary>
        /// The unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the room
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The maximum number of people in the room
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The location that this room exists at
        /// <see cref="Location"/>
        /// </summary>
        public string LocationId { get; set; }
    }
}
