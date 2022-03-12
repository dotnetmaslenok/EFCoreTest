﻿using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreTest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ToDoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddControllers();

	        services.AddDbContext<ApplicationDbContext>(options
		        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;"));

	        services.AddSwaggerGen(config =>
	        {
		        config.SwaggerDoc("v1", new OpenApiInfo { Title = "ForumApi", Version = "v1" });
	        });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
	        if (env.IsDevelopment())
	        {
		        app.UseDeveloperExceptionPage();
		        app.UseSwagger();
		        app.UseSwaggerUI();
	        }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}