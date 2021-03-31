using AttendanceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Repositories
{
    /// <summary>
    /// Defines CRUD functionaility to interact with the database
    /// using EF core db context.
    /// 
    /// </summary>
    public interface IAttendanceRepository
    {
        /// <summary>
        /// Get's all of the attendance records.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceRecord>> GetAllAsync();

        /// <summary>
        /// Searches for an attendance record by it's unique ID.
        /// </summary>
        /// <param name="id">The ID of the record to search for.</param>
        /// <returns>The record if found, otherwise null. </returns>
        public Task<AttendanceRecord> GetByIdAsync(string id);

        /// <summary>
        /// Creates a attendance record that should be saved into the database
        /// when the context is saved.
        /// </summary>
        /// <param name="record">The record to create</param>
        /// <returns>The record as created in the database, otherwise null.</returns>
        public Task<AttendanceRecord> CreateAsync(AttendanceRecord record);

        /// <summary>
        /// Saves all pending changes on the current context. Additions, deletions, and 
        /// updates will all be run against the backing database at this time.
        /// </summary>
        /// <returns></returns>
        public Task SaveChangesAsync();
    }
}
