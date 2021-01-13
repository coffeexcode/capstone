using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Entities
{
    public class AttendanceRecord
    {
        public string Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string UserId { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string EntityId { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string EntityType { get; set; }

        public string EntityDescription { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime ScanTime { get; set; }
    }
}
