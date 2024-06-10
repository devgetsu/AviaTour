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
    public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUsModel>
    {
        public void Configure(EntityTypeBuilder<AboutUsModel> builder)
        {
            builder.Property(x => x.Description)
                .HasColumnType("text");
        }
    }
}
