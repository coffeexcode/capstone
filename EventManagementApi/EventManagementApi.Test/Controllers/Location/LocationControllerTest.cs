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

namespace EventManagementApi.Test.Controllers.Location
{
    public class LocationControllerTest
    {
        private Mock<ILocationService> locationService;

        private LocationController controller;

        private IList<Entities.Location> locations;

        [SetUp]
        public void Setup()
        {
            locationService = new Mock<ILocationService>();

            locationService.Setup(repo => repo.GetLocationsAsync()).ReturnsAsync(GetTestLocations());

            controller = new LocationController(null, locationService.Object);

            locations = new List<Entities.Location>()
            {
                new Entities.Location()
                {
                    Id = "1",
                    Name = "Location 1",
                    Description = "Test location #1",
                    City = "Hamilton",
                    Region = "Ontario",
                    AreaCode = "L8V 1K7",
                    Country = "CA",
                    Line1 = "30 Main St. E"
                },
                                new Entities.Location()
                {
                    Id = "2",
                    Name = "Location 2",
                    Description = "Test location #2",
                    City = "Hamilton",
                    Region = "Ontario",
                    AreaCode = "L8V 1K7",
                    Country = "CA",
                    Line1 = "31 Main St. E"
                }
            };
        }

        [Test]
        public async Task LocationReturnsAListOfLocations()
        {
            var result = await controller.GetLocations();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Location>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Count, 2);
        }

        [Test]
        public async Task CanGetALocationById()
        {
            var id = "1";
            locationService.Setup(repo => repo.GetLocationByIdAsync(id)).ReturnsAsync(GetTestLocationById(id));

            var result = await controller.GetLocationById(id);

            // Assertions
            Assert.IsInstanceOf<ActionResult<Entities.Location>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(resultObject.Id, id);
        }

        [Test]
        public async Task CanAddALocation()
        {
            var toAdd = new LocationViewModel
            {
                Id = "3",
                Name = "Location 3",
                Description = "Test location #3",
                City = "Hamilton",
                Region = "Ontario",
                AreaCode = "L8V 1K7",
                Country = "CA",
                Line1 = "31 Main St. E"
            };

            locationService.Setup(repo => repo.CreateLocationAsync(toAdd)).ReturnsAsync(CreateLocationAsync(toAdd));
            locationService.Setup(repo => repo.GetLocationsAsync()).ReturnsAsync(GetTestLocations());

            var result = await controller.GetLocations();

            // Assertions
            Assert.IsInstanceOf<ActionResult<IList<Entities.Location>>>(result);
            var resultObject = GetObjectResultContent(result);
            Assert.AreEqual(3, resultObject.Count);
        }

        private IList<Entities.Location> GetTestLocations()
        {
            return locations;
        }

        private Entities.Location GetTestLocationById(string id)
        {
            return locations.FirstOrDefault(l => l.Id == id);
        }

        private Entities.Location CreateLocationAsync(LocationViewModel model)
        {
            var created = new Entities.Location
            {
                AreaCode = model.AreaCode,
                City = model.City,
                Country = model.Country,
                Description = model.Description,
                Id = (locations.Count + 1).ToString(),
                Line1 = model.Line1,
                Line2 = model.Line2,
                Name = model.Name,
                Region = model.Region
            };

            locations.Add(created);

            return created;
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
