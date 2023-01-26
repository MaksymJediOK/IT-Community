using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace IT_Community.Server
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "IT-Community API",
                    Description = "API for IT-Community WebApp",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "IT-Community@gmail.com",
                        Name = "XXXXXX"
                    }
                });
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}
