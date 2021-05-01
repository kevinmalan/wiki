using Wiki.Core.Services.Handlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Wiki.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureAuthentication(Configuration);
            services.ConfigureAuthorization();
            services.RegisterServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
            });
            services.AddCors();
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(RegisterHandler).Assembly);

            // Use the built in JSON serialization.
            services.AddControllers()
                        .AddJsonOptions(o =>
                        {
                            o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
                options => options.WithOrigins("http://localhost:4200").AllowAnyHeader()
            );

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Wiki.API");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}