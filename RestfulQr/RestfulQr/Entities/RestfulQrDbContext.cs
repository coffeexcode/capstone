using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace RestfulQr.Entities
{
    /// <summary>
    /// An Entity Framework Core context for database operations
    /// </summary>
    public class RestfulQrDbContext : DbContext
    {
        private readonly IWebHostEnvironment environment;

        /// <summary>
        /// All api keys
        /// <see cref="ApiKey"/>
        /// </summary>
        public DbSet<ApiKey> ApiKeys { get; set; }

        /// <summary>
        /// All created qr codes
        /// <see cref="CreatedQrCode"/>
        /// </summary>
        public DbSet<CreatedQrCode> CreatedQrCodes { get; set; }

        public RestfulQrDbContext(DbContextOptions<RestfulQrDbContext> options, IWebHostEnvironment environment) : base(options)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Configure database
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApiKey>(entity =>
            {
                entity.HasKey(e => e.Key);
                entity.Property(e => e.Key).IsRequired();
                entity.Property(e => e.DateCreated).IsRequired();
            });

            builder.Entity<CreatedQrCode>(entity =>
            {
                entity.HasKey(e => e.Filename);
                entity.Property(e => e.Filename).IsRequired();
                entity.Property(e => e.Created).IsRequired();

                entity.HasOne<ApiKey>()
                    .WithMany()
                    .HasForeignKey(e => e.CreatedBy);
            });
        }
    }
}
