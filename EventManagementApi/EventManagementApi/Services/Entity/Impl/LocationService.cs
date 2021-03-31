using AutoMapper;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using EventManagementApi.Repositories;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity.Impl
{
    public class LocationService : ILocationService
    {
        private readonly ILogger<LocationService> logger;
        private readonly IMapper mapper;
        private readonly EventManagementDbContext context;
        private readonly ILocationRepository repository;

        public LocationService(
            ILogger<LocationService> logger,
            AutoMapper.IMapper mapper,
            EventManagementDbContext context,
            ILocationRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
        }

        public async Task<Location> CreateLocationAsync(LocationViewModel model)
        {
            try
            {
                var location = mapper.Map<Location>(model);

                var created = await repository.CreateLocationAsync(location);

                return await SaveAndReturn(created);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteLocationAsync(string locationId)
        {
            try
            {
                await repository.DeleteLocationAsync(locationId);

                await SaveAndReturn(null);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Location> GetLocationByIdAsync(string locationId)
        {
            try
            {
                var location = await repository.GetLocationByIdAsync(locationId);

                if (location != null)
                {
                    return location;
                }

                throw new Exception();
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Location>> GetLocationsAsync()
        {
            try
            {
                return await repository.GetLocationsAsync();
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Location> UpdateLocationAsync(string locationId, JsonPatchDocument<LocationViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetLocationByIdAsync(locationId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Location), locationId);
                }

                // Apply patch
                var updatedModel = mapper.Map<LocationViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedLocation = mapper.Map<Location>(updatedModel);
                updatedLocation.Id = locationId;

                // Apply changes
                var updated = await repository.UpdateLocationAsync(locationId, updatedLocation);

                return await SaveAndReturn(updated);
            } catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Location> SaveAndReturn(Location location)
        {
            await context.SaveChangesAsync();

            return location;
        }
    }
}
