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

namespace EventManagementApi.Test.Controllers.EventOfferingRegistration
{
    class EventOfferingRegistrationControllerTest
    {
        private Mock<IEventOfferingRegistrationService> eventOfferingRegistrationService;

        private EventOfferingRegistrationController controller;

        private IList<Entities.EventOfferingRegistration> eventOfferingRegistrations;

        [SetUp]
        public void Setup()
        {
            eventOfferingRegistrationService = new Mock<IEventOfferingRegistrationService>();

            eventOfferingRegistrationService.Setup(repo => repo.GetEventOfferingRegistrationsAsync()).ReturnsAsync(GetTestEventOfferingRegistrations());

            controller = new EventOfferingRegistrationController(eventOfferingRegistrationService.Object);

            eventOfferingRegistrations = new List<Entities.EventOfferingRegistration>()
            {
                new Entities.EventOfferingRegistration()
                {
                    Id = "1",
                    EventOfferingId = "1",
                    UserId = "1",
                },
                                new Entities.EventOfferingRegistration()
                {
                    Id = "2",
                    EventOfferingId = "2",
                    UserId = "1",
                }
            };
        }

        [Test]
        public async Task EventOfferingRegistrationControllerReturnsAListOfEventOfferingRegistrations()
        {
            var result = await controller.GetEventOfferingRegistrations();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.EventOfferingRegistration>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            eventOfferingRegistrationService.Setup(repo => repo.GetEventOfferingRegistrationByIdAsync(id)).ReturnsAsync(GetTestEventOfferingRegistrationById(id));

            var result = await controller.GetEventOfferingRegistrationById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.EventOfferingRegistration>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new EventOfferingRegistrationViewModel
            {
                EventOfferingId = "1",
                UserId = "3"
            };

            eventOfferingRegistrationService.Setup(repo => repo.CreateEventOfferingRegistrationAsync(toAdd)).ReturnsAsync(CreateTestEventOfferingRegistration(toAdd));
            eventOfferingRegistrationService.Setup(repo => repo.GetEventOfferingRegistrationsAsync()).ReturnsAsync(GetTestEventOfferingRegistrations());

            var result = await controller.GetEventOfferingRegistrations();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.EventOfferingRegistration>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.EventOfferingRegistration> GetTestEventOfferingRegistrations()
        {
            return eventOfferingRegistrations;
        }

        private Entities.EventOfferingRegistration GetTestEventOfferingRegistrationById(string id)
        {
            return eventOfferingRegistrations.FirstOrDefault(l => l.Id == id);
        }

        private Entities.EventOfferingRegistration CreateTestEventOfferingRegistration(EventOfferingRegistrationViewModel model)
        {
            var created = new Entities.EventOfferingRegistration
            {
                Id = "2",
                EventOfferingId = model.EventOfferingId,
                UserId = model.UserId
            };

            eventOfferingRegistrations.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
