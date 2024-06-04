using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Adress_babe.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Adress_babe.Handlers
{
    public class DeleteAdressCommandHandler : IRequestHandler<DeleteAdressCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAdressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteAdressCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Address.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res != null)
            {
                _context.Address.Remove(res);

                return new ResponseModel
                {
                    Message = "Address Deleted",
                    StatusCode = 200,
                    IsSuccess = true,
                };
            }
            return new ResponseModel
            {
                Message = "We couldnt delete",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
