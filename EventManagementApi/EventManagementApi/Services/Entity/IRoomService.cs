using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity
{
    /// <summary>
    /// Provides CRUD functionality for rooms.
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Creates a room
        /// </summary>
        /// <param name="model">The model to use to create the room </param>
        /// <returns>The created room, otherwise null. </returns>
        public Task<Room> CreateRoomAsync(RoomViewModel model);

        /// <summary>
        /// Gets all room.
        /// </summary>
        /// <returns>A list of all room. </returns>
        public Task<IList<Room>> GetRoomsAsync();

        /// <summary>
        /// Gets a single room by its unique id.
        /// </summary>
        /// <param name="roomId">The id of the room  to find.</param>
        /// <returns>The room, otherwise null. </returns>
        public Task<Room> GetRoomByIdAsync(string roomId);

        /// <summary>
        /// Updates a room
        /// </summary>
        /// <param name="roomId">The room to update.</param>
        /// <param name="patchDocument">The JSON patch documents with updates to the room</param>
        /// <returns>The updated room, otherwise the existing one if an error occurs.</returns>
        public Task<Room> UpdateRoomAsync(string roomId, JsonPatchDocument<RoomViewModel> patchDocument);

        /// <summary>
        /// Deletes a room
        /// </summary>
        /// <param name="roomId">The id of the room to delete.</param>
        /// <returns></returns>
        public Task DeleteRoomAsync(string roomId);
    }
}
