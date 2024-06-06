using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.AboutUs.AboutUs.Commands.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviaTour.Application.UseCases.AboutUs.AboutUs.Handlers.CommandHandlers
{
    public class DeleteAboutUsCommandHandler : IRequestHandler<DeleteAboutUsCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAboutUsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.AboutUs.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                _context.AboutUs.Remove(res);

                return new ResponseModel
                {
                    Message = "About Us Deleted",
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
