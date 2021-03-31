using AutoMapper;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using EventManagementApi.Repositories;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity.Impl
{
    public class RoomService : IRoomService
    {
        private readonly ILogger<RoomService> logger;
        private readonly ILocationRepository locationRepository;
        private readonly IRoomRepository roomRepository;
        private readonly EventManagementDbContext context;
        private readonly IMapper mapper;

        public RoomService(
            ILogger<RoomService> logger,
            ILocationRepository locationRepository,
            IRoomRepository roomRepository,
            EventManagementDbContext context,
            IMapper mapper)
        {
            this.logger = logger;
            this.locationRepository = locationRepository;
            this.roomRepository = roomRepository;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Room> CreateRoomAsync(RoomViewModel model)
        {
            try
            {
                await CheckLocationExists(model.LocationId);

                var room = mapper.Map<Room>(model);

                var created = roomRepository.CreateRoomAsync(room);

                return await SaveAndReturn(room);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteRoomAsync(string roomId)
        {
            try
            {
                await roomRepository.DeleteRoomAsync(roomId);

                await SaveAndReturn(null);
            } catch (EntityNotFoundException)
            {
                return;
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Room> GetRoomByIdAsync(string roomId)
        {
            try
            {
                var room = await roomRepository.GetRoomByIdAsync(roomId);

                return room;
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Room>> GetRoomsAsync()
        {
            try
            {
                return await roomRepository.GetRoomsAsync();
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Room> UpdateRoomAsync(string roomId, JsonPatchDocument<RoomViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await roomRepository.GetRoomByIdAsync(roomId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Room), roomId);
                }

                var originalLocation = toUpdate.LocationId;

                // Apply patch
                var updatedModel = mapper.Map<RoomViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);

                // Check if the locationId has changed
                // If it has, check validity of new location
                if (updatedModel.LocationId != originalLocation)
                {
                    await CheckLocationExists(updatedModel.LocationId);
                }

                var updatedRoom = mapper.Map<Room>(updatedModel);
                updatedRoom.Id = roomId;

                // Save
                var updated = await roomRepository.UpdateRoomAsync(roomId, updatedRoom);

                return await SaveAndReturn(updated);
            } catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<bool> CheckLocationExists(string locationId)
        {
            var exists = (await locationRepository.GetLocationByIdAsync(locationId)) != null;

            if (exists)
            {
                return true;
            }
            else throw new EntityNotFoundException(typeof(Location), locationId);
        }

        private async Task<Room> SaveAndReturn(Room room)
        {
            await context.SaveChangesAsync();

            return room;
        }
    }
}
