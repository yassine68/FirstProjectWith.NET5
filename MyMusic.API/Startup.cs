using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyArtist.Core.Services;
using MyMusic.Core;
using MyMusic.Core.Services;
using MyMusic.Data.SqlServer;
using MyMusic.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.API
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
            // Configure the HTTP Requests for Web API
            services.AddControllers().AddNewtonsoftJson(
                option =>
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddControllers();
            services.AddDbContext<MyMusicDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("MusicDbConnection"),
                x => x.MigrationsAssembly("MyMusic.Data.SqlServer"))
                );


            // DI : Services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IMusicService, MusicService>();

            // Swagger
            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Ismael Music API", Description = "ASP.NET 5.0" });
               });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // For the Mapping Between UI Requests/controllers and App Controlles
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
                c.RoutePrefix = "";
            });
        }
    }
}
