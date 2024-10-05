using Microsoft.AspNetCore.Diagnostics;
using PRM392_Backend.Domain.ErrorModel;
using PRM392_Backend.Domain.Exceptions;

namespace PRM392_Backend.API
{
	public class GlobalExceptionHandler : IExceptionHandler
	{

		public GlobalExceptionHandler()
		{
		}
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			httpContext.Response.ContentType = "application/json";

			var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
			if (contextFeature is not null)
			{
				httpContext.Response.StatusCode = contextFeature.Error switch
				{
					NotFoundException => StatusCodes.Status404NotFound,
					_ => StatusCodes.Status500InternalServerError,
				};
				await httpContext.Response.WriteAsync(new ErrorDetail()
				{
					StatusCode = httpContext.Response.StatusCode,
					Message = contextFeature.Error.Message
				}.ToString());
			}
			return true;
		}
	}
}
