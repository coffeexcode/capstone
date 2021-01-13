using AttendanceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Repositories.Impl
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext db;

        public AttendanceRepository(AttendanceDbContext db)
        {
            this.db = db;
        }

        public async Task<AttendanceRecord> CreateAsync(AttendanceRecord record)
        {
            var result = await db.AttendanceRecords.AddAsync(record);

            if (result.State == EntityState.Added)
            {
                return result.Entity;
            }
            else return null;
        }

        public async Task<IEnumerable<AttendanceRecord>> GetAllAsync()
        {
            return await db.AttendanceRecords.AsNoTracking().ToArrayAsync();
        }

        public async Task<AttendanceRecord> GetByIdAsync(string id)
        {
            return await db.AttendanceRecords.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
