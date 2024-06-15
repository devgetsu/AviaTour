using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Tours.Commands;
using AviaTour.Application.UseCases.Tours.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateTourAsync([FromForm] CreateTourCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{pageIndex}/{size}")]
        public async Task<ActionResult<IEnumerable<Tour>>> GetAllToursAsync(int pageIndex, int size)
        {
            var query = new GetAllToursQuery()
            {
                Index = pageIndex,
                Size = size
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTourById(long id)
        {
            var query = new GetTourByIdQuery()
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateTourAsync([FromForm] UpdateTourCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> Delete(long id)
        {

            var command = new DeleteTourCommand()
            {
                Id = id
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
