using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Tours.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Handlers.CommandHandlers
{
    public class DeleteTourCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTourCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<ResponseModel> Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return new ResponseModel()
                {
                    Message = "",
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }
    }
}
