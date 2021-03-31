using EventManagementApi.Core.Data;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Repositories.Impl
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly ILogger<SponsorRepository> logger;
        private readonly EventManagementDbContext context;

        public SponsorRepository(
            ILogger<SponsorRepository> logger,
            EventManagementDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<Sponsor> CreateSponsorAsync(Sponsor sponsor)
        {
            var added = await context.Sponsors.AddAsync(sponsor);

            if (added.State == EntityState.Added)
            {
                return added.Entity;
            }
            else throw new EntityNotChangedException(typeof(Sponsor), sponsor.Id);
        }

        public async Task DeleteSponsorAsync(string sponsorId)
        {
            var toRemove = await GetSponsorByIdAsync(sponsorId);

            if (toRemove == null)
            {
                return;
            }

            var removed = context.Sponsors.Remove(toRemove);

            if (removed.State != EntityState.Deleted)
            {
                throw new EntityNotChangedException(typeof(Sponsor), sponsorId);
            }
        }

        public async Task<Sponsor> GetSponsorByIdAsync(string sponsorId)
        {
            return await context.Sponsors.AsNoTracking().FirstOrDefaultAsync(c => c.Id == sponsorId);
        }

        public async Task<IList<Sponsor>> GetSponsorsAsync()
        {
            return await context.Sponsors.AsNoTracking().ToListAsync();
        }

        public async Task<Sponsor> UpdateSponsorAsync(string sponsorId, Sponsor sponsor)
        {
            var toUpdate = await GetSponsorByIdAsync(sponsorId);

            if (toUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Sponsor), sponsorId);
            }

            toUpdate = sponsor;

            var updated = context.Sponsors.Update(toUpdate);

            if (updated.State != EntityState.Modified)
            {
                throw new EntityNotChangedException(typeof(Sponsor), sponsorId);
            }

            return updated.Entity;
        }
    }
}
