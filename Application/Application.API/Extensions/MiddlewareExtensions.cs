using Application.API.Middleware;

namespace Application.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseApiMiddleware(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            // 🔥 Exception handling FIRST
            app.UseCustomExceptionHandling();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

    }
}
