using AviaTour.Application.Models;
using AviaTour.Application.UseCases.AboutUs.AboutUs.Commands.Commands;
using AviaTour.Application.UseCases.AboutUs.AboutUs.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutUsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Create(CreateAboutUsCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<AboutUsModel>> GetAll()
        {
            var result = await _mediator.Send(new GetAllAboutUsQuery());

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel>> Update(UpdateAboutUsCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> Delete(long id)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var command = new DeleteAboutUsCommand()
            {
                Id = id
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
