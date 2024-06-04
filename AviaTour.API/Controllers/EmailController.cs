using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Adress_babe.Commands;
using AviaTour.Application.UseCases.Adress_babe.Queries;
using AviaTour.Application.UseCases.Emails.Commands;
using AviaTour.Application.UseCases.Emails.Queries;
using AviaTour.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public EmailController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateEmail(CreateEmailCommand news)
        {
            var res = await _mediatr.Send(news);
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<EmailAddressModel>> GetAllEmails([FromQuery] GetAllEmailsQuery request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateEmails(UpdateEmailCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteEmail(DeleteEmailCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
