using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Repositories;
using H3WebshopProeveprojekt.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api
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

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IAccountRoleService, AccountRoleService>();
            services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();




            services.AddDbContext<H3WebshopProeveprojektContext>(
                x => x.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "H3WebshopProeveprojekt.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "H3WebshopProeveprojekt.Api v1"));
            }

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
