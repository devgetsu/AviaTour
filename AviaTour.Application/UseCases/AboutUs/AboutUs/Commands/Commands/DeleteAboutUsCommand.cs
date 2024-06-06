using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.AboutUs.AboutUs.Commands.Commands
{
    public class DeleteAboutUsCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
