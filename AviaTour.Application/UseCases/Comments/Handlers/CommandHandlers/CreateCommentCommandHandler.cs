using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Comments.Commands;
using MediatR;
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

        public Task<ResponseModel> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
