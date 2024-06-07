using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace AviaTour.Application.UseCases.Extensions
{
    public class WriteToTelegramBotService : IWriteToTelegramBotService
    {
        private readonly long _groupid = -4271808172;
        private readonly TelegramBotClient _botClient;

        public WriteToTelegramBotService(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task LogError(Exception ex, CancellationToken cancellationToken = default)
        {
           await _botClient.SendTextMessageAsync(chatId: _groupid, text: ex.Message, cancellationToken: cancellationToken);
        }
    }
}
