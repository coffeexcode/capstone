using AttendanceAPI.Entities;
using AttendanceAPI.ViewModels;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Services
{
    public interface IAttendanceService
    {
        public Task<IEnumerable<AttendanceRecord>> GetAllAsync();

        public Task<IEnumerable<AttendanceRecord>> GetAllAsync(SieveModel model);

        public Task<AttendanceRecord> GetByIdAsync(string id);

        public Task<AttendanceRecord> CreateAsync(AttendanceRecordViewModel model);
    }
}
