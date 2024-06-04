using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Adress_babe.Commands
{
    public class DeleteAdressCommand: IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
