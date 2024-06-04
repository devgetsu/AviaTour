using AviaTour.Application.Models;
using MediatR;

namespace AviaTour.Application.UseCases.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string Message { get; set; }
    }
}
