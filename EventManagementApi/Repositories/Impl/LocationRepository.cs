using EventManagementApi.Core.Data;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILogger<LocationRepository> logger;
        private readonly EventManagementDbContext context;

        public LocationRepository(
            ILogger<LocationRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Location> CreateLocationAsync(Location location)
        {
            var added = await context.Locations.AddAsync(location);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(Location), location.Id);
        }

        public async Task DeleteLocationAsync(string locationId)
        {
            var toRemove = await GetLocationByIdAsync(locationId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Locations.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Location), locationId);
            }
        }

        public async Task<Location> GetLocationByIdAsync(string locationId)
        {
            return await context.Locations.AsNoTracking().FirstOrDefaultAsync(c => c.Id == locationId);
        }

        public async Task<IList<Location>> GetLocationsAsync()
        {
            return await context.Locations.AsNoTracking().ToListAsync();
        }

        public async Task<Location> UpdateLocationAsync(string locationId, Location location)
        {
            var toUpdate = await GetLocationByIdAsync(locationId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Location), locationId);
            }

            toUpdate = location;

            var updated = context.Locations.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Location), locationId);
            }

            return updated.Entity;
        }
    }
}
