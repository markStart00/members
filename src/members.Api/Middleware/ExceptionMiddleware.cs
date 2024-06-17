﻿
using System.Text.Json;

namespace members.Api.Middleware
{
	public class ExceptionMiddleware
	{

		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task InvokeAsync( HttpContext context, ILogger<ExceptionMiddleware> logger ) 
		{
			try 
			{
				await _next(context);
			}
			catch ( Exception ex)
			{
				logger.LogError(ex, "{Message}", ex.Message );
				await HandleExceptionAsync( context, ex );
			}
		}

		public Task HandleExceptionAsync( HttpContext context, Exception ex ) 
		{
			context.Response.StatusCode = ex switch 
			{
				_ => StatusCodes.Status500InternalServerError
			};

			var response = JsonSerializer.Serialize( new { error = ex.Message } );
			context.Response.ContentType = "application/json";

			return context.Response.WriteAsync(response);
		}

	}
}
