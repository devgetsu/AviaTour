using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Adress_babe.Commands;
using AviaTour.Application.UseCases.Adress_babe.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AddressController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateCar(CreateAdressCommand news)
        {
            var res = await _mediatr.Send(news);
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAllCars([FromQuery] GetAllAdressQuery request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateCar(UpdateAdressCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteCar(DeleteAdressCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
