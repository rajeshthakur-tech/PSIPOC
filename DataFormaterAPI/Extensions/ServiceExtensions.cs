using Microsoft.Extensions.DependencyInjection;

namespace DataFormaterAPI.Extensions
{
    /// <summary>
    /// This class is used to configure Swagger integration
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configure Swagger UI
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "PSI POC API",
                    Version = "v1",
                    Description = "POC Service for PSI",


                });
            });
        }
    }
}
