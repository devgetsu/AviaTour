using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Adress_babe.Commands;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Adress_babe.Handlers
{
    public class CreateAdressCommandHandler : IRequestHandler<CreateAdressCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateAdressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateAdressCommand request, CancellationToken cancellationToken)
        {
            var adress = new Address()
            {
                Door = request.Door,
                Street = request.Street,
                District = request.District,
                City = request.City,
                ZipCode = request.ZipCode,
                Longitude = request.Longitude,
                Latitude = request.Latitude
            };
            await _context.Address.AddAsync(adress);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Address created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
