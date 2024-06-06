using AviaTour.Application.Models;
using AviaTour.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.AboutUs.AboutUs.Commands.Commands
{
    public class CreateAboutUsCommand : IRequest<ResponseModel>
    {
        public List<Address> Addresses { get; set; }
        public List<ContactModel> Contacts { get; set; }
        public List<EmailAddressModel> Emails { get; set; }
        public string Description { get; set; }
    }
}
