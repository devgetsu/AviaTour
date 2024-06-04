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
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasQueryFilter(x => x.isDeleted != false);

            builder.Property(x => x.From)
                .HasMaxLength(50);

            builder.Property(x => x.To)
                .HasMaxLength(50);

            builder.Property(x => x.Message)
                .HasMaxLength(120);

        }
    }
}