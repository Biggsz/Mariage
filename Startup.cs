using System;
using Mariage.Data;
using Mariage.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace Mariage
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MariageDbContext>(o =>
                o.UseMySql(_configuration.GetConnectionString("DefaultConnectionString"), mo => mo.ServerVersion(new ServerVersion(new Version(10, 32, 22))))
            );
            services.AddIdentity<MariageUser,IdentityRole>()
                    .AddEntityFrameworkStores<MariageDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(o =>
            {
                o.AddPolicy("AdminOnly", p => p.RequireClaim("Admin"));
            });


            services.AddMvc(o => o.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
        }
    }
}
