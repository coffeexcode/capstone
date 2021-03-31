using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    /// <summary>
    /// Provides CRUD functionality for locations.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Creates a location
        /// </summary>
        /// <param name="model">The model to use to create the location </param>
        /// <returns>The created location, otherwise null. </returns>
        public Task<Location> CreateLocationAsync(LocationViewModel model);

        /// <summary>
        /// Gets all location.
        /// </summary>
        /// <returns>A list of all location. </returns>
        public Task<IList<Location>> GetLocationsAsync();

        /// <summary>
        /// Gets a single location by its unique id.
        /// </summary>
        /// <param name="locationId">The id of the location  to find.</param>
        /// <returns>The location, otherwise null. </returns>
        public Task<Location> GetLocationByIdAsync(string locationId);

        /// <summary>
        /// Updates a location
        /// </summary>
        /// <param name="locationId">The registration update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the location</param>
        /// <returns>The updated location, otherwise the existing one if an error occurs.</returns>
        public Task<Location> UpdateLocationAsync(string locationId, JsonPatchDocument<LocationViewModel> patchDocument);

        /// <summary>
        /// Deletes a location
        /// </summary>
        /// <param name="locationId">The id of the location to delete.</param>
        /// <returns></returns>
        public Task DeleteLocationAsync(string locationId);
    }
}
