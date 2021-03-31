using Microsoft.EntityFrameworkCore;
using RestfulQr.Core.Exceptions;
using RestfulQr.Entities;
using System.Threading.Tasks;

namespace RestfulQr.Repositories.Impl
{
    public class EfCoreCreatedQrCodeRepository : ICreatedQrCodeRepository
    {
        private readonly RestfulQrDbContext context;

        public EfCoreCreatedQrCodeRepository(
            RestfulQrDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CanAccessFileAsync(string apiKey, string filename)
        {
            var qrCode = await GetCreatedQrCodeByFilenameAsync(filename);

            if (qrCode == null)
            {
                throw new EntryNotFoundException($"Cannot find entry with filename '{filename}'");
            }

            if (qrCode.CreatedBy == apiKey)
            {
                return true;
            }
            else return false;
        }

        public async Task<CreatedQrCode> CreateQrCodeAsync(CreatedQrCode created)
        {
            var result = await context.CreatedQrCodes.AddAsync(created);

            return result.Entity;
        }

        // This action will be validated by external services
        // Assume we can delete
        public async Task DeleteQrCodeAsync(string filename)
        {
            var toDelete = await GetCreatedQrCodeByFilenameAsync(filename);

            if (toDelete == null)
            {
                return;
            }

            context.CreatedQrCodes.Remove(toDelete);
        }

        public async Task<CreatedQrCode> GetCreatedQrCodeByFilenameAsync(string filename)
        {
            return await context.CreatedQrCodes.AsNoTracking().FirstOrDefaultAsync(c => c.Filename == filename);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
