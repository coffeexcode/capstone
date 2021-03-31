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

namespace EventManagementApi.Test.Controllers.CourseOfferingRegistration
{
    class CourseOfferingRegistrationControllerTest
    {
        private Mock<ICourseOfferingRegistrationService> courseOfferingRegistrationService;

        private CourseOfferingRegistrationController controller;

        private IList<Entities.CourseOfferingRegistration> courseOfferingRegistrations;

        [SetUp]
        public void Setup()
        {
            courseOfferingRegistrationService = new Mock<ICourseOfferingRegistrationService>();

            courseOfferingRegistrationService.Setup(repo => repo.GetCourseOfferingRegistrationsAsync()).ReturnsAsync(GetTestCourseOfferingRegistrations());

            controller = new CourseOfferingRegistrationController(courseOfferingRegistrationService.Object);

            courseOfferingRegistrations = new List<Entities.CourseOfferingRegistration>()
            {
                new Entities.CourseOfferingRegistration()
                {
                    Id = "1",
                    CourseOfferingId = "1",
                    UserId = "1",
                },
                                new Entities.CourseOfferingRegistration()
                {
                    Id = "2",
                    CourseOfferingId = "2",
                    UserId = "1",
                }
            };
        }

        [Test]
        public async Task CourseOfferingRegistrationControllerReturnsAListOfCourseOfferingRegistrations()
        {
            var result = await controller.GetCourseOfferingRegistrations();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.CourseOfferingRegistration>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            courseOfferingRegistrationService.Setup(repo => repo.GetCourseOfferingRegistrationByIdAsync(id)).ReturnsAsync(GetTestCourseOfferingRegistrationById(id));

            var result = await controller.GetCourseOfferingRegistrationById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.CourseOfferingRegistration>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new CourseOfferingRegistrationViewModel
            {
                CourseOfferingId = "1",
                UserId = "3"
            };

            courseOfferingRegistrationService.Setup(repo => repo.CreateCourseOfferingRegistrationAsync(toAdd)).ReturnsAsync(CreateTestCourseOfferingRegistration(toAdd));
            courseOfferingRegistrationService.Setup(repo => repo.GetCourseOfferingRegistrationsAsync()).ReturnsAsync(GetTestCourseOfferingRegistrations());

            var result = await controller.GetCourseOfferingRegistrations();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.CourseOfferingRegistration>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.CourseOfferingRegistration> GetTestCourseOfferingRegistrations()
        {
            return courseOfferingRegistrations;
        }

        private Entities.CourseOfferingRegistration GetTestCourseOfferingRegistrationById(string id)
        {
            return courseOfferingRegistrations.FirstOrDefault(l => l.Id == id);
        }

        private Entities.CourseOfferingRegistration CreateTestCourseOfferingRegistration(CourseOfferingRegistrationViewModel model)
        {
            var created = new Entities.CourseOfferingRegistration
            {
                Id = "2",
                CourseOfferingId = model.CourseOfferingId,
                UserId = model.UserId
            };

            courseOfferingRegistrations.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
