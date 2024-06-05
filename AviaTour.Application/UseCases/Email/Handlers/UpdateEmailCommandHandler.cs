using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Emails.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Email.Handlers
{
    public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Emails.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                res.EmailAddress = request.EmailAddress;

                _context.Emails.Update(res);
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
