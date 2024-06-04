using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string Message { get; set; }
    }
}
