using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Contact.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Contact.Handlers.QueriesHandler
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, IEnumerable<ContactModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllContactQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactModel>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Contacts.ToListAsync(cancellationToken);
            return res;
        }
    }
}
