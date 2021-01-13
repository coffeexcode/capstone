using AttendanceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Repositories
{
    public interface IAttendanceRepository
    {
        public Task<IEnumerable<AttendanceRecord>> GetAllAsync();

        public Task<AttendanceRecord> GetByIdAsync(string id);

        public Task<AttendanceRecord> CreateAsync(AttendanceRecord record);

        public Task SaveChangesAsync();
    }
}
