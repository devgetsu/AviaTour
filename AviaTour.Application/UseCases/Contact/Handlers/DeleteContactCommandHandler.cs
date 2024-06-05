using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Contact.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Contact.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res != null)
            {
                _context.Contacts.Remove(res);

                return new ResponseModel
                {
                    Message = "Contact Deleted",
                    StatusCode = 200,
                    IsSuccess = true,
                };
            }
            return new ResponseModel
            {
                Message = "We couldn't delete",
                StatusCode = 401,
                IsSuccess = true
            };
        }
    }
}
