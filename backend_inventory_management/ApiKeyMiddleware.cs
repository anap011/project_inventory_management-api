namespace backend_inventory_management
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string? APIKEY = "x-api-key";
        private readonly string? _apiKeyValue;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKeyValue = configuration.GetValue<string>("ApiKey");
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Put ||
                context.Request.Method == HttpMethods.Post ||
                context.Request.Method == HttpMethods.Delete)
            {
                if ((!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey) ) || (!_apiKeyValue.Equals(extractedApiKey) ))
                        {
                    context.Response.StatusCode = 401; // Sin autorización
                    await context.Response.WriteAsync("Clave API no autorizada");
                    return;
                }
            }
            await _next(context);
        }
    }
}