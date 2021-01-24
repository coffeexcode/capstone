using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface ISponsorRepository
    {
        public Task<Sponsor> CreateSponsorAsync(Sponsor sponsor);

        public Task<IList<Sponsor>> GetSponsorsAsync();

        public Task<Sponsor> GetSponsorByIdAsync(string sponsorId);

        public Task<Sponsor> UpdateSponsorAsync(string sponsorId, Sponsor sponsor);

        public Task DeleteSponsorAsync(string sponsorId);
    }
}
