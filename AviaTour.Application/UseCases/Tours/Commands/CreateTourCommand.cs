using AviaTour.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AviaTour.Application.UseCases.Tours.Commands
{
    public class CreateTourCommand : IRequest<ResponseModel>
    {
        public string WhereEx { get; set; }
        public string Where { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public IFormFile PicturePath { get; set; }
        public long Price { get; set; }
    }
}