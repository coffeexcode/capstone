using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class TimeslotViewModel
    {
        /// <summary>
        /// The unique id of the timeslot
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the timeslot.
        /// If provided, the name should be displayed
        /// </summary>
        [MaxLength(10)]
        public string Name { get; set; }

        /// <summary>
        /// The start/end time of the timeslot
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// The end date/time of the timeslot
        /// </summary>
        [Required]
        public DateTime End { get; set; }
    }
}
