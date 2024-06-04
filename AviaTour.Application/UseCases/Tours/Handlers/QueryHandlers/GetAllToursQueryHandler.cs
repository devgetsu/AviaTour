using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Tours.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Handlers.QueryHandlers
{
    public class GetAllToursQueryHandler(IApplicationDbContext context) : IRequestHandler<GetAllToursQuery, IEnumerable<Tour>>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<IEnumerable<Tour>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tours.Skip(request.Index - 1).Take(request.Size).ToListAsync();
        }
    }
}
