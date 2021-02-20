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

namespace EventManagementApi.Test.Controllers.Event
{
    class EventControllerTest
    {
        private Mock<IEventService> eventService;

        private EventController controller;

        private IList<Entities.Event> events;

        [SetUp]
        public void Setup()
        {
            eventService = new Mock<IEventService>();

            eventService.Setup(repo => repo.GetEventsAsync()).ReturnsAsync(GetTestEvents());

            controller = new EventController(null, eventService.Object);

            events = new List<Entities.Event>()
            {
                new Entities.Event()
                {
                    Id = "1",
                    Name = "Location 1",
                    Description = "Test location #1",
                },
                                new Entities.Event()
                {
                    Id = "2",
                    Name = "Location 2",
                    Description = "Test location #2",
                }
            };
        }

        [Test]
        public async Task EventControllerReturnsAListOfEvents()
        {
            var result = await controller.GetEvents();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Event>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            eventService.Setup(repo => repo.GetEventByIdAsync(id)).ReturnsAsync(GetTestEventById(id));

            var result = await controller.GetEventById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.Event>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new EventViewModel
            {
                Name = "Location 3",
                Description = "Test location #3",
            };

            eventService.Setup(repo => repo.CreateEventAsync(toAdd)).ReturnsAsync(CreateTestEvent(toAdd));
            eventService.Setup(repo => repo.GetEventsAsync()).ReturnsAsync(GetTestEvents());

            var result = await controller.GetEvents();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Event>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.Event> GetTestEvents()
        {
            return events;
        }

        private Entities.Event GetTestEventById(string id)
        {
            return events.FirstOrDefault(l => l.Id == id);
        }

        private Entities.Event CreateTestEvent(EventViewModel model)
        {
            var created = new Entities.Event
            {
                Description = model.Description,
                Id = (events.Count + 1).ToString(),
                Name = model.Name,
            };

            events.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
