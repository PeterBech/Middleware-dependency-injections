using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MinBlazorApp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log før request behandles
            Console.WriteLine($"Request modtaget: {DateTime.Now} - {context.Request.Path}");

            // Kald næste middleware i pipelinen
            await _next(context);

            // Log efter request er behandlet
            Console.WriteLine($"Response sendt: {DateTime.Now} - Statuskode: {context.Response.StatusCode}");
        }
    }

}