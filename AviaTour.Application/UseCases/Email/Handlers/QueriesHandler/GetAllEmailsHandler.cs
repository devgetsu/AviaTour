using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Adress_babe.Queries;
using AviaTour.Application.UseCases.Emails.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Email.Handlers.QueriesHandler
{
    public class GetAllEmailsHandler : IRequestHandler<GetAllEmailsQuery, IEnumerable<EmailAddressModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllEmailsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmailAddressModel>> Handle(GetAllEmailsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Emails.ToListAsync(cancellationToken);
            return res;
        }
    }
}
