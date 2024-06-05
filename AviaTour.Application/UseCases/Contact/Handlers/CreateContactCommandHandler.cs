using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Contact.Commands;
using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Contact.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new ContactModel()
            {
                PhoneNumber = request.PhoneNumber
            };
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Contact created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
