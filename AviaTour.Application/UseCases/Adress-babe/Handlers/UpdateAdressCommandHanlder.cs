using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Adress_babe.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Adress_babe.Handlers
{
    public class UpdateAdressCommandHanlder : IRequestHandler<UpdateAdressCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAdressCommandHanlder(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateAdressCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Address.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                res.Door = request.Door;
                res.Street = request.Street;
                res.District = request.District;
                res.City = request.City;
                res.ZipCode = request.ZipCode;
                res.Longitude = request.Longitude;
                res.Latitude = request.Latitude;

                _context.Address.Update(res);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Changes saved!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponseModel()
            {
                Message = "Error while updating!",
                StatusCode = 401
            };
        }
    }
}
