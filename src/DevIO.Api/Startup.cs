using DevIO.Api.Configuration;
using DevIO.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;

namespace DevIO.Api
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
            services.AddDbContext<MeuDbContext>(optionsAction: options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(name: "DefaultConnection"));
            });

            services.AddIdentityConfig(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddApiConfig();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc(name: "V1", new Info { Title = "My API", Version = "v1" });
            //});
            services.AddSwaggerConfig();

            services.ResolveDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development"); // CORS Must be called first
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseAuthentication(); // MUST ALWAYS COME BEFORE UseApiConfig

            app.UseApiConfig();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My API V1");
            //});
            app.UseSwaggerConfig(provider);
        }
    }
}
