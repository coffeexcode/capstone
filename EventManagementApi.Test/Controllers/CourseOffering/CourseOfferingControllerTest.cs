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

namespace EventManagementApi.Test.Controllers.CourseOffering
{
    class CourseOfferingControllerTest
    {
        private Mock<ICourseOfferingService> courseOfferingService;

        private CourseOfferingController controller;

        private IList<Entities.CourseOffering> timeslots;

        [SetUp]
        public void Setup()
        {
            courseOfferingService = new Mock<ICourseOfferingService>();

            courseOfferingService.Setup(repo => repo.GetCourseOfferingsAsync()).ReturnsAsync(GetTestCourseOfferings());

            controller = new CourseOfferingController(courseOfferingService.Object);

            timeslots = new List<Entities.CourseOffering>()
            {
                new Entities.CourseOffering()
                {
                    Id = "1",
                    CourseId = "1",
                    InstructorId = "1",
                    RoomId = "1",
                    TimeslotId = "1", 
                },
                                new Entities.CourseOffering()
                {
                    Id = "2",
                    CourseId = "1",
                    InstructorId = "1",
                    RoomId = "1",
                    TimeslotId = "1",
                },
            };
        }

        [Test]
        public async Task CourseOfferingControllerReturnsAListOfCourseOfferings()
        {
            var result = await controller.GetCourseOfferings();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.CourseOffering>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            courseOfferingService.Setup(repo => repo.GetCourseOfferingByIdAsync(id)).ReturnsAsync(GetTestCourseOfferingById(id));

            var result = await controller.GetCourseOfferingById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.CourseOffering>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new CourseOfferingViewModel
            {
                CourseId = "1",
                InstructorId = "1",
                RoomId = "1",
                TimeslotId = "1",
            };

            courseOfferingService.Setup(repo => repo.CreateCourseOfferingAsync(toAdd)).ReturnsAsync(CreateTestCourseOffering(toAdd));
            courseOfferingService.Setup(repo => repo.GetCourseOfferingsAsync()).ReturnsAsync(GetTestCourseOfferings());

            var result = await controller.GetCourseOfferings();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.CourseOffering>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.CourseOffering> GetTestCourseOfferings()
        {
            return timeslots;
        }

        private Entities.CourseOffering GetTestCourseOfferingById(string id)
        {
            return timeslots.FirstOrDefault(l => l.Id == id);
        }

        private Entities.CourseOffering CreateTestCourseOffering(CourseOfferingViewModel model)
        {
            var created = new Entities.CourseOffering
            {
                Id = "2",
                CourseId = model.CourseId,
                InstructorId = model.InstructorId,
                RoomId = model.RoomId,
                TimeslotId = model.TimeslotId
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
