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

namespace EventManagementApi.Test.Controllers.Course
{
    class CourseControllerTest
    {
        private Mock<ICourseService> courseService;

        private CourseController controller;

        private IList<Entities.Course> courses;

        [SetUp]
        public void Setup()
        {
            courseService = new Mock<ICourseService>();

            courseService.Setup(repo => repo.GetCoursesAsync()).ReturnsAsync(GetTestCourses());

            controller = new CourseController(null, courseService.Object);

            courses = new List<Entities.Course>()
            {
                new Entities.Course()
                {
                    Id = "1",
                    Name = "Location 1",
                    Description = "Test location #1",
                },
                                new Entities.Course()
                {
                    Id = "2",
                    Name = "Location 2",
                    Description = "Test location #2",
                }
            };
        }

        [Test]
        public async Task CourseControllerReturnsAListOfCourses()
        {
            var result = await controller.GetCourses();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Course>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            courseService.Setup(repo => repo.GetCourseByIdAsync(id)).ReturnsAsync(GetTestCourseById(id));

            var result = await controller.GetCourseById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.Course>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new CourseViewModel
            {
                Name = "Location 3",
                Description = "Test location #3",
            };

            courseService.Setup(repo => repo.CreateCourseAsync(toAdd)).ReturnsAsync(CreateTestCourse(toAdd));
            courseService.Setup(repo => repo.GetCoursesAsync()).ReturnsAsync(GetTestCourses());

            var result = await controller.GetCourses();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Course>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.Course> GetTestCourses()
        {
            return courses;
        }

        private Entities.Course GetTestCourseById(string id)
        {
            return courses.FirstOrDefault(l => l.Id == id);
        }

        private Entities.Course CreateTestCourse(CourseViewModel model)
        {
            var created = new Entities.Course
            {
                Description = model.Description,
                Id = (courses.Count + 1).ToString(),
                Name = model.Name,
            };

            courses.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
