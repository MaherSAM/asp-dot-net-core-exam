namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Simple simulation: Check for a header named "X-API-TOKEN"
            // In a real scenario, you would validate a JWT Bearer token here.

            if (!context.Request.Headers.TryGetValue("X-API-TOKEN", out var extractedToken))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized: Missing Token");
                return;
            }

            // Hardcoded valid token for the exam simulation
            if (!extractedToken.Equals("SuperSecretToken123"))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized: Invalid Token");
                return;
            }

            await _next(context);
        }
    }
}