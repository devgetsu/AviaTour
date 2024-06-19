using AviaTour.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Extensions.EmailSenderService
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(BookingModel model);
    }
}
