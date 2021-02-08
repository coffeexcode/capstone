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

namespace EventManagementApi.Test.Controllers.Instructor
{
    class InstructorControllerTest
    {
        private Mock<IInstructorService> instructorService;

        private InstructorController controller;

        private IList<Entities.Instructor> instructors;

        [SetUp]
        public void Setup()
        {
            instructorService = new Mock<IInstructorService>();

            instructorService.Setup(repo => repo.GetInstructorsAsync()).ReturnsAsync(GetTestInstructors());

            controller = new InstructorController(null, instructorService.Object);

            instructors = new List<Entities.Instructor>()
            {
                new Entities.Instructor()
                {
                    Id = "1",
                    Email = "test@gmail.com",
                    FirstName = "Test",
                    LastName = "Person",
                    Phone = "905-123-4567"
                },
                                new Entities.Instructor()
                {
                    Id = "2",
                    Email = "test@yahoo.com",
                    FirstName = "Tester",
                    LastName = "Account",
                    Phone = "905-123-4567"
                }
            };
        }

        [Test]
        public async Task InstructorControllerReturnsAListOfInstructors()
        {
            var result = await controller.GetInstructors();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Instructor>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            instructorService.Setup(repo => repo.GetInstructorByIdAsync(id)).ReturnsAsync(GetTestInstructorById(id));

            var result = await controller.GetInstructorById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.Instructor>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new InstructorViewModel
            {
                Email = "faker@yahoo.com",
                FirstName = "Fake",
                LastName = "Account",
                Phone = "905-123-4567"
            };

            instructorService.Setup(repo => repo.CreateInstructorAsync(toAdd)).ReturnsAsync(CreateTestInstructor(toAdd));
            instructorService.Setup(repo => repo.GetInstructorsAsync()).ReturnsAsync(GetTestInstructors());

            var result = await controller.GetInstructors();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Instructor>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.Instructor> GetTestInstructors()
        {
            return instructors;
        }

        private Entities.Instructor GetTestInstructorById(string id)
        {
            return instructors.FirstOrDefault(l => l.Id == id);
        }

        private Entities.Instructor CreateTestInstructor(InstructorViewModel model)
        {
            var created = new Entities.Instructor
            {
                Email = "test@yahoo.com",
                FirstName = "Tester",
                LastName = "Account",
                Phone = "905-123-4567",
                Id = (instructors.Count + 1).ToString()
            };

            instructors.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
