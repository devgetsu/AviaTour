using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Adress_babe.Commands
{
    public class UpdateAdressCommand: IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string Door { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public long ZipCode { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }
}
