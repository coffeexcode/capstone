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

namespace EventManagementApi.Test.Controllers.Timeslot
{
    class TimeslotControllerTest
    {
        private Mock<ITimeslotService> timeslotService;

        private TimeslotController controller;

        private IList<Entities.Timeslot> timeslots;

        [SetUp]
        public void Setup()
        {
            timeslotService = new Mock<ITimeslotService>();

            timeslotService.Setup(repo => repo.GetTimeslotsAsync()).ReturnsAsync(GetTestTimeslots());

            controller = new TimeslotController(null, timeslotService.Object);

            timeslots = new List<Entities.Timeslot>()
            {
                new Entities.Timeslot()
                {
                    Id = "1",
                    Name = "Test Timeslot 1",
                    End = DateTime.Now,
                    Start = DateTime.Now
                },
                                new Entities.Timeslot()
                {
                    Id = "2",
                    End = DateTime.Now,
                    Start = DateTime.Now,
                    Name = "Test Timeslot 2"
                },
            };
        }

        [Test]
        public async Task TimeslotControllerReturnsAListOfTimeslots()
        {
            var result = await controller.GetTimeslots();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Timeslot>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            timeslotService.Setup(repo => repo.GetTimeslotByIdAsync(id)).ReturnsAsync(GetTestTimeslotById(id));

            var result = await controller.GetTimeslotById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.Timeslot>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new TimeslotViewModel
            {
                End = DateTime.Now,
                Start = DateTime.Now,
                Name = "Test Timeslot 3"
            };

            timeslotService.Setup(repo => repo.CreateTimeslotAsync(toAdd)).ReturnsAsync(CreateTestTimeslot(toAdd));
            timeslotService.Setup(repo => repo.GetTimeslotsAsync()).ReturnsAsync(GetTestTimeslots());

            var result = await controller.GetTimeslots();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Timeslot>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.Timeslot> GetTestTimeslots()
        {
            return timeslots;
        }

        private Entities.Timeslot GetTestTimeslotById(string id)
        {
            return timeslots.FirstOrDefault(l => l.Id == id);
        }

        private Entities.Timeslot CreateTestTimeslot(TimeslotViewModel model)
        {
            var created = new Entities.Timeslot
            {
                Id = (timeslots.Count + 1).ToString(),
                End = DateTime.Now,
                Start = DateTime.Now,
                Name = "Test Timeslot 2"
            };

            timeslots.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
