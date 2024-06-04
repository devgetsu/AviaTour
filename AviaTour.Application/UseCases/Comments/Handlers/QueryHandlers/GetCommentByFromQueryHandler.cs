using AviaTour.Application.Abstractions;
using AviaTour.Application.UseCases.Comments.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Handlers.QueryHandlers
{
    public class GetCommentByFromQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCommentByToQuery, IEnumerable<Comment>>
    {
        private readonly IApplicationDbContext _context = context;

        public Task<IEnumerable<Comment>> Handle(GetCommentByToQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // hozircha bitta model uchun yozib chiqamiz to uchun alohida model ochilishi kerak
        }
    }
}
