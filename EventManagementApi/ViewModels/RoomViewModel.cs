using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class RoomViewModel
    {
        /// <summary>
        /// The unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the room
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// A short description of the room
        /// </summary>
        [Required]
        [MaxLength(255)]
        [MinLength(25)]
        public string Description { get; set; }

        /// <summary>
        /// The maximum number of people in the room
        /// </summary>
        [Required]
        public int Capacity { get; set; }

        /// <summary>
        /// The location that this room exists at
        /// <see cref="Location"/>
        /// </summary>
        [Required]
        [MaxLength(36)] 
        [MinLength(36)]
        public string LocationId { get; set; }
    }
}
