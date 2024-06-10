using AviaTour.API.Interfaces;
using AviaTour.Application.UseCases.Extensions;
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
                _logger.LogInfo("Here is info message from the controller.");
                await _requestDelegate(context);
            }
            catch (ValidationException ex)
            {
                int code = 400;
                _logger.LogInfo("Here is info message from the controller.");
                await HandleExceptionAsync(context, ex, code);
            }
            catch (Exception ex)
            {

                await _writeToTelegramBotService.LogError(ex);
                _logger.LogInfo("Here is info message from the controller.");
                await HandleExceptionAsync(context, ex, context.Response.StatusCode);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, int code)
        {
            _logger.LogInfo("Here is info message from the controller.");
            context.Response.StatusCode = code;
            return;
        }
    }
}

