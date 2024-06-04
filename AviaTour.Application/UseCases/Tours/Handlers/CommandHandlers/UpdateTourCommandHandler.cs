using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Tours.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Handlers.CommandHandlers
{
    public class UpdateTourCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateTourCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context = context;

        public Task<ResponseModel> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
