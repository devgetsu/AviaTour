using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Queries
{
    public class GetCommentsByTourId : IRequest<IEnumerable<Comment>>
    {
        public long TourId { get; set; }
    }
}
