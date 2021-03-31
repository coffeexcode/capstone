using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for locations.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Creates a location regiustration in the backing database.
        /// </summary>
        /// <param name="location">The location to create in the database. </param>
        /// <returns>The created location as in the database. </returns>
        public Task<Location> CreateLocationAsync(Location location);

        /// <summary>
        /// Gets all locations in the backing database.
        /// </summary>
        /// <returns>A list of all locations registrations. </returns>
        public Task<IList<Location>> GetLocationsAsync();

        /// <summary>
        /// Gets single location by its unique id.
        /// </summary>
        /// <param name="locationId">The id of the location to find.</param>
        /// <returns>The location, otherwise null. </returns>
        public Task<Location> GetLocationByIdAsync(string locationId);

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="locationId">The id of the location to update in the database. </param>
        /// <param name="location">The location entity to overwrite with. </param>
        /// <returns>The updated location, otherwise the existing one if an error occurs.</returns>
        public Task<Location> UpdateLocationAsync(string locationId, Location location);

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="locationId">The id of the location to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteLocationAsync(string locationId);
    }
}
