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
    public interface ILocationService
    {
        public Task<Location> CreateLocationAsync(LocationViewModel model);

        public Task<IList<Location>> GetLocationsAsync();

        public Task<Location> GetLocationByIdAsync(string locationId);

        public Task<Location> UpdateLocationAsync(string locationId, JsonPatchDocument<LocationViewModel> patchDocument);

        public Task DeleteLocationAsync(string locationId);
    }
}
