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

    namespace EventManagementApi.Test.Controllers.Sponsor
    {
        class SponsorControllerTest
        {
            private Mock<ISponsorService> sponsorService;

            private SponsorController controller;

            private IList<Entities.Sponsor> sponsors;

            [SetUp]
            public void Setup()
            {
                sponsorService = new Mock<ISponsorService>();

                sponsorService.Setup(repo => repo.GetSponsorsAsync()).ReturnsAsync(GetTestSponsors());

                controller = new SponsorController(null, sponsorService.Object);

                sponsors = new List<Entities.Sponsor>()
            {
                new Entities.Sponsor()
                {
                    Id = "1",
                    ContactEmail = "1@test.com",
                    ContactFirstName = "Test 1",
                    ContactLastName = "Test 1",
                    ContactPhone = "905-123-4567",
                    Name = "Test Sponsor 1"
                },
                                new Entities.Sponsor()
                {
                    Id = "2",
                    ContactEmail = "2@test.com",
                    ContactFirstName = "Test 2",
                    ContactLastName = "Test 2",
                    ContactPhone = "905-123-4567",
                    Name = "Test Sponsor 2"
                },
            };
            }

            [Test]
            public async Task SponsorControllerReturnsAListOfSponsors()
            {
                var result = await controller.GetSponsors();

                // Assertions
                Assert.IsInstanceOf<ActionResult<IList<Entities.Sponsor>>>(result);
                var resultObject = GetObjectResultContent(result);
                Assert.AreEqual(resultObject.Count, 2);
            }

            [Test]
            public async Task CanGetALocationById()
            {
                var id = "1";
                sponsorService.Setup(repo => repo.GetSponsorByIdAsync(id)).ReturnsAsync(GetTestSponsorById(id));

                var result = await controller.GetSponsorById(id);

                // Assertions
                Assert.IsInstanceOf<ActionResult<Entities.Sponsor>>(result);
                var resultObject = GetObjectResultContent(result);
                Assert.AreEqual(resultObject.Id, id);
            }

            [Test]
            public async Task CanAddALocation()
            {
            var toAdd = new SponsorViewModel
            {
                Id = "3",
                ContactEmail = "3@test.com",
                ContactFirstName = "Test 3",
                ContactLastName = "Test 3",
                ContactPhone = "905-123-4567",
                Name = "Test Sponsor 3"
            };

                sponsorService.Setup(repo => repo.CreateSponsorAsync(toAdd)).ReturnsAsync(CreateTestSponsor(toAdd));
                sponsorService.Setup(repo => repo.GetSponsorsAsync()).ReturnsAsync(GetTestSponsors());

                var result = await controller.GetSponsors();

                // Assertions
                Assert.IsInstanceOf<ActionResult<IList<Entities.Sponsor>>>(result);
                var resultObject = GetObjectResultContent(result);
                Assert.AreEqual(3, resultObject.Count);
            }

            private IList<Entities.Sponsor> GetTestSponsors()
            {
                return sponsors;
            }

            private Entities.Sponsor GetTestSponsorById(string id)
            {
                return sponsors.FirstOrDefault(l => l.Id == id);
            }

            private Entities.Sponsor CreateTestSponsor(SponsorViewModel model)
            {
            var created = new Entities.Sponsor
            {
                Id = (sponsors.Count + 1).ToString(),
                ContactEmail = "2@test.com",
                ContactFirstName = "Test 2",
                ContactLastName = "Test 2",
                ContactPhone = "905-123-4567",
                Name = "Test Sponsor 2"
            };

                sponsors.Add(created);

                return created;
            }

            private static T GetObjectResultContent<T>(ActionResult<T> result)
            {
                return (T)((ObjectResult)result.Result).Value;
            }
        }
    }
