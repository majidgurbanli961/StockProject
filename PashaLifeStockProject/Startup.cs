using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PashaLifeStockProject.Data.Context;
using PashaLifeStockProject.Middlewares;
using PashaLifeStockProject.Repo.Abstract;
using PashaLifeStockProject.Repo.Concrete;
using PashaLifeStockProject.Service.Abstract;
using PashaLifeStockProject.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PashaLifeStockProject
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
            services.AddDbContextPool<StockDbContext>(options => options.UseSqlServer(
           "Server=DESKTOP-41BCSBQ;Database=StockDb;Trusted_Connection=True")
            


           );
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IStockRepo, StockRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));


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
