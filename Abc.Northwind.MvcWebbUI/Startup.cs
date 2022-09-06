using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.MvcWebbUI.Entities;
using Abc.Northwind.MvcWebbUI.Middlewares;//new app.
using Abc.Northwind.MvcWebUI.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.MvcWebbUI
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
            services.AddScoped<IProductService, ProductManager>();//using eklenecek
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<ICategoryService, CategoryManager>();//using eklenecek
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddRazorPages();
            services.AddMvc();
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-CP1963V\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddHttpClient();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            //app.UseNodeModules(env.ContentRootPath);
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
           
            app.UseStaticFiles();
            app.UseHttpsRedirection();   
            app.UseCors();
            app.UseRouting();
            app.UseFileServer();
       
            app.UseAuthorization();
            //app.UseMvcWithDefaultRoute();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Product}/{action=Index}");
                
            });
        }
    }
}
