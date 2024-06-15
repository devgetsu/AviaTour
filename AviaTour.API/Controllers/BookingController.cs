using AviaTour.Application.Models;
using AviaTour.Application.UseCases.Extensions.EmailSenderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public BookingController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task SendEmail(BookingModel model)
        {
            await _emailSender.SendEmailAsync(model);
        }
    }
}
