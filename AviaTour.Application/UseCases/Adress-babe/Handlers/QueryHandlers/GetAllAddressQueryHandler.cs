using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Adress_babe.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Adress_babe.Handlers.QueryHandlers
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAdressQuery, IEnumerable<Address>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAddressQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> Handle(GetAllAdressQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Address.ToListAsync(cancellationToken);
            return res;
        }
    }
}
