using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Tours.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviaTour.Application.UseCases.Tours.Handlers.QueryHandlers;
public class GetTourByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTourByIdQuery, Tour>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Tour> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tours.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new Exception();
    }
}