using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories
{
    /// <summary>
    /// Provides CRUD functionality at the database level
    /// for rooms.
    /// </summary>
    public interface IRoomRepository
    {
        /// <summary>
        /// Creates a room regiustration in the backing database.
        /// </summary>
        /// <param name="room">The room to create in the database. </param>
        /// <returns>The created room as in the database. </returns>
        public Task<Room> CreateRoomAsync(Room room);

        /// <summary>
        /// Gets all rooms in the backing database.
        /// </summary>
        /// <returns>A list of all rooms registrations. </returns>
        public Task<IList<Room>> GetRoomsAsync();

        /// <summary>
        /// Gets single room by its unique id.
        /// </summary>
        /// <param name="roomId">The id of the room to find.</param>
        /// <returns>The room, otherwise null. </returns>
        public Task<Room> GetRoomByIdAsync(string roomId);

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="roomId">The id of the room to update in the database. </param>
        /// <param name="room">The room entity to overwrite with. </param>
        /// <returns>The updated room, otherwise the existing one if an error occurs.</returns>
        public Task<Room> UpdateRoomAsync(string roomId, Room room);

        /// <summary>
        /// Deletes a room.
        /// </summary>
        /// <param name="roomId">The id of the room to delete in the database.</param>
        /// <returns></returns>
        public Task DeleteRoomAsync(string roomId);
    }
}
