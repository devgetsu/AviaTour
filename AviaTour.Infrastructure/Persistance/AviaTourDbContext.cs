using AviaTour.Application.Abstractions;
using AviaTour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Infrastructure.Persistance
{
    public class AviaTourDbContext : DbContext, IApplicationDbContext
    {
        public AviaTourDbContext(DbContextOptions<AviaTourDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<EmailAddressModel> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
