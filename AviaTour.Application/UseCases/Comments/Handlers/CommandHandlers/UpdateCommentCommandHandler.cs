using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Comments.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Handlers.CommandHandlers
{
    public class UpdateCommentCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateCommentCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<ResponseModel> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (comment == null)
                    throw new Exception();

                comment.Message = request.Message;
                comment.ModifiedAt = DateTimeOffset.UtcNow;

                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel()
                {
                    Message = "Updated",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
