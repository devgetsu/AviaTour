using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Contact.Commands
{
    public class CreateContactCommand: IRequest<ResponseModel>
    {
        public string PhoneNumber { get; set; }
    }
}
