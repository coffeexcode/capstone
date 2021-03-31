using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class InstructorViewModel
    {
        /// <summary>
        /// The unique id of the instructor
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The first name of the instructor
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the instructor
        /// </summary>
        [Required]
        [MaxLength(255)] 
        public string LastName { get; set; }

        /// <summary>
        /// The email address of the instructor
        /// </summary>
        [Required]
        [MaxLength(255)] 
        public string Email { get; set; }

        /// <summary>
        /// The phone number of the instructor
        /// </summary>
        [Required]
        [MaxLength(50)] 
        public string Phone { get; set; }
    }
}
