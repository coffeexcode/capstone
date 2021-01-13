using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.ViewModels
{
    public class AttendanceRecordViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string EntityId { get; set; }

        [Required]
        public string EntityType { get; set; }

        public string EntityDescription { get; set; }

        [Required]
        public DateTime ScanTime { get; set; }
    }
}
