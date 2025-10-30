using GestaoEstoqueApi.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case RegraNegocioException ex:
                    statusCode = HttpStatusCode.BadRequest; 
                    message = ex.Message;
                    break;
                case RecursoNaoEncontradoException ex:
                    statusCode = HttpStatusCode.NotFound; 
                    message = ex.Message;
                    break;
                default:
                    _logger.LogError(exception, "Ocorreu um erro inesperado."); 
                    statusCode = HttpStatusCode.InternalServerError; 
                    message = "Ocorreu um erro interno inesperado.";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new { erro = message });
            return context.Response.WriteAsync(result);
        }
    }
}