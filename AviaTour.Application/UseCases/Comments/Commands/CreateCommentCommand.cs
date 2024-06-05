using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Commands
{
    public class CreateCommentCommand : IRequest<ResponseModel>
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
        public long TourId { get; set; }
    }
}
