using AviaTour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Infrastructure.Configurations
{
    public class TourConfigurations : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(x => x.Where)
                .HasMaxLength(80);

            builder.Property(x => x.WhereEx)
                .HasMaxLength(80);

            builder.Property(x => x.Subtitle)
                .HasMaxLength(170);

            builder.Property("Descripton")
                .HasMaxLength(1800);
            
            builder.HasQueryFilter(x => x.IsDeleted != false);

            
        }
    }
}
