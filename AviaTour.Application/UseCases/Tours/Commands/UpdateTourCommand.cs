using AviaTour.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Commands
{
    public class UpdateTourCommand : IRequest<ResponseModel>
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string WhereEx { get; set; }
        [Required]
        public string Where { get; set; }
        [Required]
        public string Subtitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile PicturePath { get; set; }
        [Required]
        public long Price { get; set; }
    }
}
