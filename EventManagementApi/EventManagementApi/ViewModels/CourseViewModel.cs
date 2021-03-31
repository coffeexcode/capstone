using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class CourseViewModel
    {
        /// <summary>
        /// The unique id of the course
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the course
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// A short description of the course
        /// </summary>
        [Required]
        [MaxLength(1024)] 
        [MinLength(50)]
        public string Description { get; set; }
    }
}
