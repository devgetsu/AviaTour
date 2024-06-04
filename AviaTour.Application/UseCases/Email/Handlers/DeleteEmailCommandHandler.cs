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
    public class DeleteEmailCommandHandler : IRequestHandler<DeleteEmailCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteEmailCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Emails.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res != null)
            {
                _context.Emails.Remove(res);

                return new ResponseModel
                {
                    Message = "Email Deleted",
                    StatusCode = 200,
                    IsSuccess = true,
                };
            }
            return new ResponseModel
            {
                Message = "We couldn't delete",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
