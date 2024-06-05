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
    public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
    {
        //public string Address { get; set; }
        //public string Contact { get; set; }
        //public string Email { get; set; }
        //public string Description { get; set; }

        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.Property(x => x.Description)
                .HasColumnType("text");
        }
    }
}
