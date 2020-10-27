using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class Instructor
    {
        /// <summary>
        /// The unique id of the instructor
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The first name of the instructor
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the instructor
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The email address of the instructor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The phone number of the instructor
        /// </summary>
        public string Phone { get; set; }
    }
}
