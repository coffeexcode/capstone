using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    public interface IRoomRepository
    {
        public Task<Room> CreateRoomAsync(Room room);

        public Task<IList<Room>> GetRoomsAsync();

        public Task<Room> GetRoomByIdAsync(string roomId);

        public Task<Room> UpdateRoomAsync(string roomId, Room room);

        public Task DeleteRoomAsync(string roomId);
    }
}
