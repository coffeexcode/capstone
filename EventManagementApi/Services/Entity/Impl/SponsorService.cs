using AutoMapper;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using EventManagementApi.Repositories;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity.Impl
{
    public class SponsorService : ISponsorService
    {
        private readonly ILogger<SponsorService> logger;
        private readonly EventManagementDbContext context;
        private readonly ISponsorRepository repository;
        private readonly IMapper mapper;

        public SponsorService(
            ILogger<SponsorService> logger,
            EventManagementDbContext context,
            ISponsorRepository repository,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Sponsor> CreateSponsorAsync(SponsorViewModel model)
        {
            try
            {
                var sponsor = mapper.Map<Sponsor>(model);

                var created = await repository.CreateSponsorAsync(sponsor);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteSponsorAsync(string sponsorId)
        {
            try
            {
                await repository.DeleteSponsorAsync(sponsorId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Sponsor> GetSponsorByIdAsync(string sponsorId)
        {
            try
            {
                var sponsor = await repository.GetSponsorByIdAsync(sponsorId);

                return sponsor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Sponsor>> GetSponsorsAsync()
        {
            try
            {
                return await repository.GetSponsorsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Sponsor> UpdateSponsorAsync(string sponsorId, JsonPatchDocument<SponsorViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetSponsorByIdAsync(sponsorId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Sponsor), sponsorId);
                }

                // Apply patch
                var updatedModel = mapper.Map<SponsorViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);
                var updatedSponsor = mapper.Map<Sponsor>(updatedModel);
                updatedSponsor.Id = sponsorId;

                // Apply changes
                var updated = await repository.UpdateSponsorAsync(sponsorId, updatedSponsor);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Sponsor> SaveAndReturn(Sponsor sponsor)
        {
            await context.SaveChangesAsync();

            return sponsor;
        }
    }
}
