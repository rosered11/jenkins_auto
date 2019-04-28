using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DemoApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            singertonContext = new DAL.UnitOfWork();

        }
        public DAL.IUnitOfWork singertonContext {get;}
        public IConfiguration Configuration { get; }
        public Serilog.ILogger logger {get;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(o => singertonContext);
            //services.AddDbContext<DatabaseContext>(o=>o.UseSqlServer("Server=127.0.0.1,31433;Database=demo;User Id=sa;Password=pass@word1;") );
            services.AddDbContext<DatabaseContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>()..Database.Migrate();
            app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
