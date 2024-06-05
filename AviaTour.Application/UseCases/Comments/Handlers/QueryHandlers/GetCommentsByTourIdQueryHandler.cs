using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Comments.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Handlers.QueryHandlers
{
    public class GetCommentsByTourIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCommentsByTourId, IEnumerable<Comment>>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<IEnumerable<Comment>> Handle(GetCommentsByTourId request, CancellationToken cancellationToken)
        {
                var comments = await _context.Comments
                                    .Where(c => c.TourId == request.TourId)
                                        .ToListAsync(cancellationToken);
                return comments;
        }
    }
}
