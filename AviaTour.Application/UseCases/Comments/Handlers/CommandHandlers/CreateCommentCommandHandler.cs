using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Comments.Commands;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Handlers.CommandHandlers
{
    public class CreateCommentCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateCommentCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<ResponseModel> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tour = await _context.Tours.FirstOrDefaultAsync(x => x.Id == request.TourId);

                if (tour == null)
                {
                    throw new Exception("Tour not found.");
                }

                var comment = new Comment()
                {
                    From = request.From,
                    Message = request.Message,
                    TourId = request.TourId,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Tour = tour
                };

                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Created",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = ex.ToString(),
                    StatusCode = 400,
                    IsSuccess = false
                };
            }
        }
    }
}
