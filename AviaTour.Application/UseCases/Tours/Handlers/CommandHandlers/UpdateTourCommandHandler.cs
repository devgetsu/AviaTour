using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Tours.Commands;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Tours.Handlers.CommandHandlers
{
    public class UpdateTourCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : IRequestHandler<UpdateTourCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<ResponseModel> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = _context.Tours.FirstOrDefault(x => x.Id == request.Id);
            if (tour != null)
            {
                if (request.PicturePath != null)
                {
                    var photoPath = tour.PicturePath;
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                    }

                    var file = request.PicturePath;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "TourPhotos");
                    string fileName = "";

                    try
                    {
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                            Console.WriteLine("Directory created successfully.");
                        }

                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        filePath = Path.Combine(_webHostEnvironment.WebRootPath, "TourPhotos", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        tour.PicturePath = "/TourPhotos/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        return new ResponseModel()
                        {
                            Message = ex.Message,
                            StatusCode = 500,
                            IsSuccess = false
                        };
                    }
                }

                tour.Subtitle = request.Subtitle;
                tour.Where = request.Where;
                tour.WhereEx = request.WhereEx;
                tour.Description = request.Description;
                tour.Price = request.Price;
                _context.Tours.Update(tour);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    StatusCode = 201,
                    Message = "Tour Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel()
            {
                Message = "Tour is not found",
                StatusCode = 400,
                IsSuccess = false
            };
        }
    }
}
