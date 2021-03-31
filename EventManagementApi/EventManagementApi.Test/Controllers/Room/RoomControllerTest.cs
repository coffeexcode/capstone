using EventManagementApi.Controllers.Api.V1;
using EventManagementApi.Services.Entity;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApi.Test.Controllers.Room
{
    class RoomControllerTest
    {
        private Mock<IRoomService> roomService;

        private RoomController controller;

        private IList<Entities.Room> rooms;

        [SetUp]
        public void Setup()
        {
            roomService = new Mock<IRoomService>();

            roomService.Setup(repo => repo.GetRoomsAsync()).ReturnsAsync(GetTestRooms());

            controller = new RoomController(null, roomService.Object);

            rooms = new List<Entities.Room>()
            {
                new Entities.Room()
                {
                    Id = "1",
                    Name = "Test Room 1",
                    Capacity = 5,
                    Description = "Description for room 1",
                    LocationId = "1"
                },
                                new Entities.Room()
                {
                    Id = "2",
                    Capacity = 5,
                    Description = "Description for room 1",
                    LocationId = "1",
                    Name = "Test Room 2"
                },
            };
        }

        [Test]
        public async Task RoomControllerReturnsAListOfRooms()
        {
            var result = await controller.GetRooms();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Room>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            roomService.Setup(repo => repo.GetRoomByIdAsync(id)).ReturnsAsync(GetTestRoomById(id));

            var result = await controller.GetRoomById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.Room>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new RoomViewModel
            {
                Capacity = 5,
                Description = "Description for room 1",
                LocationId = "1",
                Name = "Test Room 3"
            };

            roomService.Setup(repo => repo.CreateRoomAsync(toAdd)).ReturnsAsync(CreateTestRoom(toAdd));
            roomService.Setup(repo => repo.GetRoomsAsync()).ReturnsAsync(GetTestRooms());

            var result = await controller.GetRooms();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Room>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.Room> GetTestRooms()
        {
            return rooms;
        }

        private Entities.Room GetTestRoomById(string id)
        {
            return rooms.FirstOrDefault(l => l.Id == id);
        }

        private Entities.Room CreateTestRoom(RoomViewModel model)
        {
            var created = new Entities.Room
            {
                Id = (rooms.Count + 1).ToString(),
                Capacity = 5,
                Description = "Description for room 1",
                LocationId = "1",
                Name = "Test Room 2"
            };

            rooms.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
