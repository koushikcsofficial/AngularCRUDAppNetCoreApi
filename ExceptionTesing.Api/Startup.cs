using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using NLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ExceptionTesing.Api
{
    public class Startup
    {
        private readonly ILog logger;
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()))
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new CustomError();
                        if (!context.ModelState.IsValid)
                        {
                            result = new CustomError(context.HttpContext.Response.StatusCode, "Invalid parameters supplied");
                        }
                        else
                        {
                            result = new CustomError(context.HttpContext.Response.StatusCode, "Internal server error");
                        }

                        logger.Error(context.HttpContext.ToString());

                        return new JsonResult(result);
                    };
                });
            //Singleton class service added for writing exception log
            services.AddSingleton<ILog, LogNLog>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandlerMiddleware();

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
