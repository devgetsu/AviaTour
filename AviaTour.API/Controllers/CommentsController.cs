using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Comments.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateCommentAsync(CreateCommentCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateCommentAsync(UpdateCommentCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteCommentAsync(long id)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var command = new DeleteCommentCommand()
            {
                Id = id
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
