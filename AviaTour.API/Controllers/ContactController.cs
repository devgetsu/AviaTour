using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Comments.Commands;
using AviaTour.Application.UseCases.Contact.Commands;
using AviaTour.Application.UseCases.Contact.Queries;
using AviaTour.Application.UseCases.Emails.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateContactAsync(CreateContactCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ContactModel>> GetAllContacts()
        {
            var result = await _mediator.Send(new GetAllContactQuery());
            return result;
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateContactAsync(UpdateContactCommand command)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteContactAsync(long id)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var command = new DeleteContactCommand()
            {
                Id = id
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
