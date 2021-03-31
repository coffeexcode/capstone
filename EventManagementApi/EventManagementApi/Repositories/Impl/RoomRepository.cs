using EventManagementApi.Core.Data;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ILogger<RoomRepository> logger;
        private readonly EventManagementDbContext context;

        public RoomRepository(
            ILogger<RoomRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Room> CreateRoomAsync(Room room)
        {
            var added = await context.Rooms.AddAsync(room);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(Room), room.Id);
        }

        public async Task DeleteRoomAsync(string roomId)
        {
            var toRemove = await GetRoomByIdAsync(roomId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Rooms.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Room), roomId);
            }
        }

        public async Task<Room> GetRoomByIdAsync(string roomId)
        {
            return await context.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == roomId);
        }

        public async Task<IList<Room>> GetRoomsAsync()
        {
            return await context.Rooms.AsNoTracking().ToListAsync();
        }

        public async Task<Room> UpdateRoomAsync(string roomId, Room room)
        {
            var toUpdate = await GetRoomByIdAsync(roomId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Room), roomId);
            }

            toUpdate = room;

            var updated = context.Rooms.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Room), roomId);
            }

            return updated.Entity;
        }
    }
}
