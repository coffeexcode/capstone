using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class Course
    {
        /// <summary>
        /// The unique id of the course
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the course
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the course
        /// </summary>
        public string Description { get; set; }
    }
}
