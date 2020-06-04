using Docker.DotNet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AngularSSR.Models;
using Microsoft.Extensions.Options;
using AngularSSR.Services;

namespace AngularSSR
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // services.AddDbContext<MovieContext>(opt => opt.UseMemoryCache);
            services.Configure<MovieDatabaseSettings>(
            Configuration.GetSection(nameof(MovieDatabaseSettings)));
            services.AddSingleton<IMovieDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MovieDatabaseSettings>>().Value);
            services.AddSingleton<MovieService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                /*c.RoutePrefix = string.Empty;*/
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                spa.UseSpaPrerendering(options =>
                {
                    options.BootModulePath = $"{spa.Options.SourcePath}/dist/ClientApp/server/main.js";
                    options.BootModuleBuilder = env.IsDevelopment()
                        ? new AngularCliBuilder(npmScript: "build:ssr")
                            : null;
                    options.ExcludeUrls = new[] { "/sockjs-node" };
                });

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
