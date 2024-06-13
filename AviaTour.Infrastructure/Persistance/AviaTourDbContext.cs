using AviaTour.Application.Abstractions;
using AviaTour.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AviaTour.Domain.Entities.Auth;

namespace AviaTour.Infrastructure.Persistance
{
    public class AviaTourDbContext : IdentityDbContext<User, IdentityRole<long>, long>, IApplicationDbContext
    {
        public AviaTourDbContext(DbContextOptions<AviaTourDbContext> options)
            : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<AboutUsModel> AboutUs { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<EmailAddressModel> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Tour)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TourId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
