using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace CW_3_v2.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				if (_next != null) await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;

			return context.Response.WriteAsync("Exception"); 
		}
	}
}
