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
    public class DeleteCommentCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteCommentCommand, ResponseModel>
    {
        public readonly IApplicationDbContext _context = context;

        public async Task<ResponseModel> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (comment == null)
                    throw new Exception();

                comment.isDeleted = true;
                comment.DeletedAt = DateTimeOffset.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Deleted",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = "Created",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
        }
    }
}
