using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.AboutUs.AboutUs.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.AboutUs.AboutUs.Handlers.QueryHandlers
{
    public class GetAllAboutUsQueryHandler : IRequestHandler<GetAllAboutUsQuery, IEnumerable<AboutUsModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAboutUsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AboutUsModel>> Handle(GetAllAboutUsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.AboutUs.ToListAsync(cancellationToken);
            return res;
        }
    }
}
