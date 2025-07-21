using Microsoft.EntityFrameworkCore;
using Orama_API.Domain;

namespace Orama_API.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<UserProfile> UserProfilies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId)
                      .ValueGeneratedOnAdd().UseIdentityColumn(seed: 1, increment: 1);

                entity.Property(u => u.ImageUrl);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Phone).HasMaxLength(20);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(20);
                entity.Property(u => u.Address).HasMaxLength(255);
                entity.Property(u => u.Pincode).HasMaxLength(10);
                entity.Property(u => u.DateOfBirth);
                entity.Property(u => u.Gender);
                entity.Property(u => u.Role).HasMaxLength(20).HasDefaultValue("user");
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.LastUpdated).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.LanguagePreference).HasDefaultValue("en-US");
                entity.Property(u => u.Timezone).HasMaxLength(20);
                entity.Property(u => u.IsEmailVerified).HasDefaultValue(false);
                entity.Property(u => u.IsPhoneVerified).HasDefaultValue(false);
                entity.Property(u => u.IsActive).HasDefaultValue(true);
                entity.Property(u => u.PremiunmStatus).HasMaxLength(20).IsRequired(false);
                entity.Property(u => u.Bio).HasMaxLength(255);
                entity.Property(u => u.SocialHandle);
                entity.Property(u => u.LastLogin).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
