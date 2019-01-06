using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureJar.Lambda.Service.DynamoDb.Contracts;
using AdventureJar.Lambda.Service.DynamoDb.Tables;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AdventureJar.Lambda.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "AdventureJar.Lambda.Api",
                    Description = "This project shows how to run an ASP.NET Core Web API project as an AWS Lambda exposed through Amazon API Gateway.",
                    Contact = new Contact
                    {
                        Name = "Heinrich Venter",
                        Email = "Heini141@outlook.com",
                        Url = "https://github.com/Heinrichv"
                    }
                });
            });
            services.AddCors();
            services.AddMemoryCache();
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
            services.AddAWSService<IAmazonDynamoDB>();

            services.AddScoped<IActivity, Activity>();
            services.AddScoped<IAccount, Account>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Prod/swagger/v1/swagger.json", "AdventureJar.Lambda.Api");
            });
            app.UseMvc();
        }
    }
}
