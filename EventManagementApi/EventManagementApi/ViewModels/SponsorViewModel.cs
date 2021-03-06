﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.ViewModels
{
    public class SponsorViewModel
    {
        /// <summary>
        /// The unique id for the sponsor
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the sponsor.
        /// For companies, this is often the company name
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// The first name of the contact who registered the sponsor.
        /// </summary>
        [Required]
        [MaxLength(255)] 
        public string ContactFirstName { get; set; }

        /// <summary>
        /// The last name of the contact who registered the sponsor.
        /// </summary>
        [Required]
        [MaxLength(255)] 
        public string ContactLastName { get; set; }

        /// <summary>
        /// The email address of the contact who registered the sponsor.
        /// </summary>
        [Required]
        [MaxLength(255)] 
        public string ContactEmail { get; set; }

        /// <summary>
        /// The phone number of the contact who registered the sponsor.
        /// </summary>
        [Required]
        [MaxLength(255)] 
        public string ContactPhone { get; set; }
    }
}
