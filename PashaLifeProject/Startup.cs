using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PashaLifeProject.Data.Context;
using PashaLifeProject.Middlewares;
using PashaLifeProject.Repo.Abstract;
using PashaLifeProject.Repo.Concrete;
using PashaLifeProject.Service.Abstract;
using PashaLifeProject.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PashaLifeProject
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
            services.AddControllers();
            services.AddDbContextPool<PashaLifeDbContext>(options => options.UseSqlServer(
            "Server=DESKTOP-41BCSBQ;Database=PashaLifeDb;Trusted_Connection=True")


            );
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryRepo, ProductCategoryRepo>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();
            app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
