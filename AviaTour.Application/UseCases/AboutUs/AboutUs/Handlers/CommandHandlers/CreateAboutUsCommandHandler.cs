using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.AboutUs.AboutUs.Commands.Commands;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviaTour.Application.UseCases.AboutUs.AboutUs.Handlers.CommandHandlers
{
    public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateAboutUsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var info = new AboutUsModel()
            {
                Description = request.Description
            };

            await _context.AboutUs.AddAsync(info);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                Message = "About Us created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
