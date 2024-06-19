using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Extensions.TelegramSenderService
{
    public interface IWriteToTelegramBotService
    {
        public Task LogError(Exception ex, CancellationToken cancellationToken = default);
    }
}
