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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                res.PhoneNumber= request.PhoneNumber;
                _context.Contacts.Update(res);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Changes saved!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            return new ResponseModel()
            {
                Message = "Error while updating!",
                StatusCode = 401
            };
        }
    }
}
