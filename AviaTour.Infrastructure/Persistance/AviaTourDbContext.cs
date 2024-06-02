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
