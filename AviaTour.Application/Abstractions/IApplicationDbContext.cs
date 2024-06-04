using AviaTour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Comment> Comments { get; set; }
        DbSet<AboutUs> AboutUs { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Email> Emails { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
    }
}
