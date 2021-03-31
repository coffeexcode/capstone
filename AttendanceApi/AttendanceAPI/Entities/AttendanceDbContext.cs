using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Entities
{
    /// <summary>
    /// Configures an EF core database context to connect to the backing
    /// store.
    /// </summary>
    public class AttendanceDbContext : DbContext
    {
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AttendanceRecord
            builder.Entity<AttendanceRecord>(attendanceRecord =>
            {
                attendanceRecord.Property(a => a.Id).ValueGeneratedOnAdd();

                attendanceRecord.Property(a => a.UserId).IsRequired();
                attendanceRecord.Property(a => a.EntityId).IsRequired();
                attendanceRecord.Property(a => a.EntityType).IsRequired();
                attendanceRecord.Property(a => a.ScanTime).IsRequired();
            });
        }
    }
}
