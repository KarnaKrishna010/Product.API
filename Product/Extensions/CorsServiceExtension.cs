using Product.Models.Common;

namespace Product.API.Extensions
{
    public static class CorsServiceExtension
    {
        private static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsPolicySettings = configuration.GetSection("MyAppCorsPolicySettings").Get<MyAppCorsPolicyOptions>();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();

                    });
            });
        }
    }
}
