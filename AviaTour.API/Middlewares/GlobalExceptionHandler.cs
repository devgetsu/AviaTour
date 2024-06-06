using AviaTour.Application.UseCases.Extensions;
using System.ComponentModel.DataAnnotations;

namespace AviaTour.API.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IWriteToTelegramBotService _writeToTelegramBotService;
        public GlobalExceptionHandler(RequestDelegate requestDelegate, IWriteToTelegramBotService writeToTelegramBotService)
        {
            _requestDelegate = requestDelegate;
            _writeToTelegramBotService = writeToTelegramBotService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ValidationException ex)
            {
                int code = 400;
                await HandleExceptionAsync(context, ex, code);
            }
            catch (Exception ex)
            {
                //Write to Telegram channel

                await _writeToTelegramBotService.LogError(ex);


                //Write to Log file



                await HandleExceptionAsync(context, ex, context.Response.StatusCode);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, int code)
        {
            context.Response.StatusCode = code;
            return;
        }
    }
}

