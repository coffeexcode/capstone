using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class EventViewModel
    {
        /// <summary>
        /// The unique id of the event
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the event
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// A short description of the event
        /// </summary>
        [Required]
        [MaxLength(1024)] 
        [MinLength(25)]
        public string Description { get; set; }

        /// <summary>
        /// When the event starts
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// When the event is over
        /// </summary>
        [Required]
        public DateTime End { get; set; }

        /// <summary>
        /// The unique id of the room that the event is taking place at.
        /// <see cref="Room"/>
        /// </summary>
        [Required]
        [MaxLength(36)] 
        [MinLength(36)]
        public string RoomId { get; set; }
    }
}
