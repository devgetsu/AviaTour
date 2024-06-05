using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Queries
{
    public class GetTourByIdQuery : IRequest<Tour>
    {
        public long Id { get; set; }
    }
}
