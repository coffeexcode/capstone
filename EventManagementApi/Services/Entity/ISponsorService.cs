using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface ISponsorService
    {
        public Task<Sponsor> CreateSponsorAsync(SponsorViewModel model);

        public Task<IList<Sponsor>> GetSponsorsAsync();

        public Task<Sponsor> GetSponsorByIdAsync(string sponsorId);

        public Task<Sponsor> UpdateSponsorAsync(string sponsorId, JsonPatchDocument<SponsorViewModel> patchDocument);

        public Task DeleteSponsorAsync(string sponsorId);
    }
}
