using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    public interface IRoomService
    {
        public Task<Room> CreateRoomAsync(RoomViewModel model);

        public Task<IList<Room>> GetRoomsAsync();

        public Task<Room> GetRoomByIdAsync(string roomId);

        public Task<Room> UpdateRoomAsync(string roomId, JsonPatchDocument<RoomViewModel> patchDocument);

        public Task DeleteRoomAsync(string roomId);
    }
}
