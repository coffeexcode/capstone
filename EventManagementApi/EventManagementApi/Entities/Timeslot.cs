using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class Timeslot
    {
        /// <summary>
        /// The unique id of the timeslot
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the timeslot.
        /// If provided, the name should be displayed
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The start/end time of the timeslot
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The end date/time of the timeslot
        /// </summary>
        public DateTime End { get; set; }
    }
}
