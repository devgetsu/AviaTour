using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Tours.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviaTour.Application.UseCases.Tours.Handlers.QueryHandlers;

public class GetTourByCommentCountHandler(IApplicationDbContext context) : IRequestHandler<GetTourByCommentCount, IEnumerable<Tour>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<Tour>> Handle(GetTourByCommentCount request, CancellationToken cancellationToken)
    {
        return await _context.Tours.OrderByDescending(t => t.Comments.Count).Take(request.Size).ToListAsync();
    }
}
