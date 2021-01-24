using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class Location
    {
        /// <summary>
        /// The unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the location
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the location
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Line1 of the address for the location
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// The Line2 of the address for the location
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// The city of the location
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The region of the location (province / state)
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The country of the location
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The area code of the location (postal code / zip)
        /// </summary>
        public string AreaCode { get; set; }
    }
}
