using Customer.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer.Api
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
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DevConnection")
                )
            );
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()))
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new CustomError();
                        if (!context.ModelState.IsValid)
                        {
                            result = new CustomError(501,"Invalid Model");
                        }
                        else
                        {
                            //result = new BadRequestObjectResult(context.ModelState);
                            result = new CustomError(500, "Internal server error");
                        }
                        return new JsonResult(result);
                    };
                }); ;

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new CustomValidationResponseActionFilter());
            //});

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options=> options.WithOrigins("http://localhost:7638", "http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                        );
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
