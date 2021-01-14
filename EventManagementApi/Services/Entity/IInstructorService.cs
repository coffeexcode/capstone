using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface IInstructorService
    {
        public Task<Instructor> CreateInstructorAsync(InstructorViewModel model);

        public Task<IList<Instructor>> GetInstructorsAsync();

        public Task<Instructor> GetInstructorByIdAsync(string instructorId);

        public Task<Instructor> UpdateInstructorAsync(string instructorId, JsonPatchDocument<InstructorViewModel> patchDocument);

        public Task DeleteInstructorAsync(string instructorId);
    }
}
