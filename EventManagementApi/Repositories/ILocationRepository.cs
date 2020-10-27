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
    public interface ILocationRepository
    {
        public Task<Location> CreateLocationAsync(Location location);

        public Task<IList<Location>> GetLocationsAsync();

        public Task<Location> GetLocationByIdAsync(string locationId);

        public Task<Location> UpdateLocationAsync(string locationId, Location location);

        public Task DeleteLocationAsync(string locationId);
    }
}
