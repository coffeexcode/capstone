using AttendanceAPI.Entities;
using AttendanceAPI.Repositories;
using AttendanceAPI.ViewModels;
using AutoMapper;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Services.Impl
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository repository;
        private readonly IMapper mapper;
        private readonly SieveProcessor sieve;

        public AttendanceService(IAttendanceRepository repository, IMapper mapper, SieveProcessor sieve)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.sieve = sieve;
        }

        public async Task<AttendanceRecord> CreateAsync(AttendanceRecordViewModel model)
        {
            // Create the entity
            var toCreate = mapper.Map<AttendanceRecord>(model);

            // Send to repository
            var created = await repository.CreateAsync(toCreate);

            if (created == null)
            {
                throw new Exception();
            }

            // Save changes
            await repository.SaveChangesAsync();

            return created;
        }

        public async Task<IEnumerable<AttendanceRecord>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<IEnumerable<AttendanceRecord>> GetAllAsync(SieveModel model)
        {
            var allRecords = await repository.GetAllAsync();
            
            var filtered = sieve.Apply(model, allRecords.AsQueryable());

            return filtered.AsEnumerable();
        }

        public async Task<AttendanceRecord> GetByIdAsync(string id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
