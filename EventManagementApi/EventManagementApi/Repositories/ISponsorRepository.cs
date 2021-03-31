using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for sponsors.
    /// </summary>
    public interface ISponsorRepository
    {
        /// <summary>
        /// Creates a sponsor regiustration in the backing database.
        /// </summary>
        /// <param name="sponsor">The sponsor to create in the database. </param>
        /// <returns>The created sponsor as in the database. </returns>
        public Task<Sponsor> CreateSponsorAsync(Sponsor sponsor);

        /// <summary>
        /// Gets all sponsors in the backing database.
        /// </summary>
        /// <returns>A list of all sponsors registrations. </returns>
        public Task<IList<Sponsor>> GetSponsorsAsync();

        /// <summary>
        /// Gets single sponsor by its unique id.
        /// </summary>
        /// <param name="sponsorId">The id of the sponsor to find.</param>
        /// <returns>The sponsor, otherwise null. </returns>
        public Task<Sponsor> GetSponsorByIdAsync(string sponsorId);

        /// <summary>
        /// Updates a sponsor.
        /// </summary>
        /// <param name="sponsorId">The id of the sponsor to update in the database. </param>
        /// <param name="sponsor">The sponsor entity to overwrite with. </param>
        /// <returns>The updated sponsor, otherwise the existing one if an error occurs.</returns>
        public Task<Sponsor> UpdateSponsorAsync(string sponsorId, Sponsor sponsor);

        /// <summary>
        /// Deletes a sponsor.
        /// </summary>
        /// <param name="sponsorId">The id of the sponsor to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteSponsorAsync(string sponsorId);
    }
}
