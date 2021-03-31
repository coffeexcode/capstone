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

namespace EventManagementApi.Test.Controllers.EventOffering
{
    class EventOfferingControllerTest
    {
        private Mock<IEventOfferingService> eventOfferingService;

        private EventOfferingController controller;

        private IList<Entities.EventOffering> eventOfferings;

        [SetUp]
        public void Setup()
        {
            eventOfferingService = new Mock<IEventOfferingService>();

            eventOfferingService.Setup(repo => repo.GetEventOfferingsAsync()).ReturnsAsync(GetTestEventOfferings());

            controller = new EventOfferingController(eventOfferingService.Object);

            eventOfferings = new List<Entities.EventOffering>()
            {
                new Entities.EventOffering()
                {
                    Id = "1",
                    EventId = "1",
                    TimeslotId = "1",
                    RoomId = "1",
                },
                                new Entities.EventOffering()
                {
                    Id = "2",
                    EventId = "1",
                    TimeslotId = "1",
                    RoomId = "1",
                }
            };
        }

        [Test]
        public async Task EventOfferingControllerReturnsAListOfEventOfferings()
        {
            var result = await controller.GetEventOfferings();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.EventOffering>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            eventOfferingService.Setup(repo => repo.GetEventOfferingByIdAsync(id)).ReturnsAsync(GetTestEventOfferingById(id));

            var result = await controller.GetEventOfferingById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.EventOffering>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new EventOfferingViewModel
            {
                EventId = "1",
                TimeslotId = "1",
                RoomId = "1",
            };

            eventOfferingService.Setup(repo => repo.CreateEventOfferingAsync(toAdd)).ReturnsAsync(CreateTestEventOffering(toAdd));
            eventOfferingService.Setup(repo => repo.GetEventOfferingsAsync()).ReturnsAsync(GetTestEventOfferings());

            var result = await controller.GetEventOfferings();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.EventOffering>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.EventOffering> GetTestEventOfferings()
        {
            return eventOfferings;
        }

        private Entities.EventOffering GetTestEventOfferingById(string id)
        {
            return eventOfferings.FirstOrDefault(l => l.Id == id);
        }

        private Entities.EventOffering CreateTestEventOffering(EventOfferingViewModel model)
        {
            var created = new Entities.EventOffering
            {
                Id = (eventOfferings.Count + 1).ToString(),
                EventId = model.EventId,
                TimeslotId = model.TimeslotId,
                RoomId = model.RoomId
            };

            eventOfferings.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
