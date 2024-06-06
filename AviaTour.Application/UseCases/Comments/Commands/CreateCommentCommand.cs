using AviaTour.Application.Models;
using MediatR;

namespace AviaTour.Application.UseCases.Comments.Commands
{
    public class CreateCommentCommand : IRequest<ResponseModel>
    {
        public string From { get; set; }
        public string Message { get; set; }
        public long TourId { get; set; }
    }
}
