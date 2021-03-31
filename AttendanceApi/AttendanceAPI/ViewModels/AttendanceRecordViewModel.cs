using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.ViewModels
{
    /// <summary>
    /// The fields used to create a attendance record.
    /// These should be posted as JSON to this API.
    /// </summary>
    public class AttendanceRecordViewModel
    {
        /// <summary>
        /// The user Id this record is for.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the entity this record is supposed to track.
        /// This can be one of a few types, defined by EntityType.
        /// </summary>
        [Required]
        public string EntityId { get; set; }

        /// <summary>
        /// The type of entity that this attendance record is for.
        /// For example, course, hospitality, etc.
        /// </summary>
        [Required]
        public string EntityType { get; set; }

        /// <summary>
        /// The description of the entity.
        /// For example, course name, hopsitality event name, etc.
        /// </summary>
        public string EntityDescription { get; set; }

        /// <summary>
        /// The time that this attendance record was generated.
        /// This will be the time the user scanned in/out of
        /// the provided Entity.
        /// </summary>
        [Required]
        public DateTime ScanTime { get; set; }
    }
}
