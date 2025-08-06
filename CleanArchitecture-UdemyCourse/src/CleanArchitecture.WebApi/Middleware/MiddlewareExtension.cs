namespace CleanArchitecture.WebApi.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder app) {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
