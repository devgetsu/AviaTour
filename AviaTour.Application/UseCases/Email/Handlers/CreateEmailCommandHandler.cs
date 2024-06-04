using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Emails.Commands;
using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Emails.Handlers
{
    public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
        {
            var email = new EmailAddressModel()
            {
                EmailAddress = request.EmailAddress
            };
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Email created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
