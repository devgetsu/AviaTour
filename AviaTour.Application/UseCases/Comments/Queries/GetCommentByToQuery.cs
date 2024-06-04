using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Queries
{
    public class GetCommentByToQuery : IRequest<IEnumerable<Comment>>
    {
        public string To { get; set; }
    }
}
