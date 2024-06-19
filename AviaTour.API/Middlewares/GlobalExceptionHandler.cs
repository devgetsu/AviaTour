using AviaTour.API.Interfaces;
using AviaTour.Application.UseCases.Extensions.TelegramSenderService;
using System.ComponentModel.DataAnnotations;

namespace AviaTour.API.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IWriteToTelegramBotService _writeToTelegramBotService;
        private readonly ILoggerManager _logger;
        public GlobalExceptionHandler(RequestDelegate requestDelegate, IWriteToTelegramBotService writeToTelegramBotService, ILoggerManager logger)
        {
            _requestDelegate = requestDelegate;
            _writeToTelegramBotService = writeToTelegramBotService;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogWarn(context.Request.Headers.ToString()!);
                await _requestDelegate(context);
            }
            catch (ValidationException ex)
            {
                int code = 400;
                HandleException(context, ex, code);
            }
            catch (Exception ex)
            {

                await _writeToTelegramBotService.LogError(ex);
                HandleException(context, ex, context.Response.StatusCode);
            }
        }

        private void HandleException(HttpContext context, Exception ex, int code)
        {
            _logger.LogInfo(ex.ToString());
            context.Response.StatusCode = code;
            return;
        }
    }
}

