using AviaTour.Application.Models;
using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Comments.Commands
{
    public class DeleteCommentCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
