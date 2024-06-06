using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.AboutUs.AboutUs.Commands.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.AboutUs.AboutUs.Handlers.CommandHandlers
{
    public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAboutUsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.AboutUs.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                res.Addresses = request.Addresses;
                res.Contacts = request.Contacts;
                res.Emails = request.Emails;
                res.Description = request.Description;

                _context.AboutUs.Update(res);

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
