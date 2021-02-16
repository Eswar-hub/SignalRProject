using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SampleSignalR
{
    public class Startup
    {
        public Startup(IConfiguration iConfiguration)
        {
            this.iConfiguration = iConfiguration;
        }
        public IConfiguration iConfiguration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
            services.AddHealthChecks();
            services.AddSignalR().AddHubOptions<Notification>(options =>
            {
                options.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
                options.KeepAliveInterval = TimeSpan.FromMinutes(15);
            });
        }
        public void Configure(IApplicationBuilder app)
        {

            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<Notification>("/notification");
            });
        }
    }
}
