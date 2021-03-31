using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    /// <summary>
    /// Provides CRUD functionality for sponsors.
    /// </summary>
    public interface ISponsorService
    {
        /// <summary>
        /// Creates a sponsor
        /// </summary>
        /// <param name="model">The model to use to create the sponsor </param>
        /// <returns>The created sponsor, otherwise null. </returns>
        public Task<Sponsor> CreateSponsorAsync(SponsorViewModel model);

        /// <summary>
        /// Gets all sponsor.
        /// </summary>
        /// <returns>A list of all sponsor. </returns>
        public Task<IList<Sponsor>> GetSponsorsAsync();

        /// <summary>
        /// Gets a single sponsor by its unique id.
        /// </summary>
        /// <param name="sponsorId">The id of the sponsor  to find.</param>
        /// <returns>The sponsor, otherwise null. </returns>
        public Task<Sponsor> GetSponsorByIdAsync(string sponsorId);

        /// <summary>
        /// Updates a sponsor
        /// </summary>
        /// <param name="sponsorId">The sponsor to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the sponsor</param>
        /// <returns>The updated sponsor, otherwise the existing one if an error occurs.</returns>
        public Task<Sponsor> UpdateSponsorAsync(string sponsorId, JsonPatchDocument<SponsorViewModel> patchDocument);

        /// <summary>
        /// Deletes a sponsor
        /// </summary>
        /// <param name="sponsorId">The id of the sponsor to delete.</param>
        /// <returns></returns>
        public Task DeleteSponsorAsync(string sponsorId);
    }
}
