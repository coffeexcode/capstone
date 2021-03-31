using AttendanceAPI.Entities;
using AttendanceAPI.ViewModels;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Services
{
    /// <summary>
    /// Exposes functionality to the attendace controller. Translates API requests into 
    /// proper operations to perform using the database (via IAttendanceRepository).
    /// </summary>
    public interface IAttendanceService
    {
        /// <summary>
        /// Returns a list of all the attendance records currently in the database.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceRecord>> GetAllAsync();

        /// <summary>
        /// Gets a list of all the attendance records currently in the database after
        /// applying some method of search/sort/filter.
        /// 
        /// </summary>
        /// <param name="model">The Sieve model to use when filtering the list.</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceRecord>> GetAllAsync(SieveModel model);

        /// <summary>
        /// Gets an attendance record by the id.
        /// </summary>
        /// <param name="id">The ID of the attenance record to retrieve. </param>
        /// <returns>The found attendance record, otherwise null. </returns>
        public Task<AttendanceRecord> GetByIdAsync(string id);

        /// <summary>
        /// Creates a attendance record based on the provided model (DTO) and
        /// saves it in the database.
        /// </summary>
        /// <param name="model">The model to create the attendance record from. </param>
        /// <returns>The created record, or null if there was an error. </returns>
        public Task<AttendanceRecord> CreateAsync(AttendanceRecordViewModel model);
    }
}
