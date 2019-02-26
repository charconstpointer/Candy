using Candy.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Candy
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", 
                builder => 
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("https://localhost")
                        .WithOrigins("http://localhost")
                        .WithOrigins("https://localhost:3000")
                        .WithOrigins("http://localhost:3000")
                        .WithOrigins("http://testcore.polskieradio.pl")
                        .WithOrigins("https://testcore.polskieradio.pl")
                        .AllowCredentials();
                }));
            services.AddMvc();
            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            }); //.AddStackExchangeRedis("localhost:4444"); //redis connection string(localhost for production only)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes => { routes.MapHub<ChatHub>("/chat"); });
             // For the wwwroot folder


            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
            //    RequestPath = "/client"
            //});
            app.Run(async context => { await context.Response.WriteAsync("/chat"); });
        }
    }
}