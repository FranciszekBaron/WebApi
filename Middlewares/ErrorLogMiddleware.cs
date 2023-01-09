namespace WebApplication1.Middlewares
{
    public class ErrorLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public ErrorLogMiddleware(RequestDelegate next, ILogger<ErrorLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "This error ocurred while program was trying to make the request");
                throw;

            }
        }
    }
}
