using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface IInstructorRepository
    {
        public Task<Instructor> CreateInstructorAsync(Instructor instructor);

        public Task<IList<Instructor>> GetInstructorsAsync();

        public Task<Instructor> GetInstructorByIdAsync(string instructorId);

        public Task<Instructor> UpdateInstructorAsync(string instructorId, Instructor instructor);

        public Task DeleteInstructorAsync(string instructorId);
    }
}
