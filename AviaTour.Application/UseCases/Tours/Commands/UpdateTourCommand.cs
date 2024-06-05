using AviaTour.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Commands
{
    public class UpdateTourCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string WhereEx { get; set; }
        public string Where { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public IFormFile PicturePath { get; set; }
        public long Price { get; set; }
    }
}
