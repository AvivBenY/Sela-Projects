using AnimalSiteProject.Models;
using AnimalSiteProject.Services;
using AnimalSiteProject.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject
{
    public class Startup
    {        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=AnimalsDB1;Trusted_Connection=True;";
            services.AddDbContext<AnimalDbContext>(options => options
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies())
            .AddScoped<IAnimalService, AnimalService>()
            .AddScoped<ICatetgoryService, CatetgoryService>()
            .AddScoped<ICommentService, CommentService>()
            .AddScoped<IAdminService, AdminService>()
            .AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AnimalDbContext adb)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            adb.Database.EnsureDeleted();
            adb.Database.EnsureCreated();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name:"default",  pattern:"{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name:"secondry",  pattern:"{controller=Home}/{action=Index}/{name}");
            });
        }
    }
}
