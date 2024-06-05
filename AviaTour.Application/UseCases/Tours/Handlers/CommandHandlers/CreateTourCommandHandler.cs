using AviaTour.Application.Abstractions;
using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Tours.Commands;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace AviaTour.Application.UseCases.Tours.Handlers.CommandHandlers
{
    public class CreateTourCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : IRequestHandler<CreateTourCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<ResponseModel> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var file = request.PicturePath;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "TourPhotos");
                string fileName = "";

                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "TourPhotos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
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

                var tour = new Tour()
                {
                    Where = request.Where,
                    WhereEx = request.WhereEx,
                    Price = request.Price,
                    Description = request.Description,
                    Subtitle = request.Subtitle,
                    CreatedAt = DateTimeOffset.UtcNow,
                    PicturePath = "/TourPhotos/" + fileName,
                };

                await _context.Tours.AddAsync(tour, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    StatusCode = 201,
                    Message = $"Tour Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel()
            {
                Message = "Tour is might be null",
                StatusCode = 400
            };
        }
    }
}
