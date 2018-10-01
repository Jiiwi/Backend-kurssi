using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace web_api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IRepository, MongoDbRepository>();
            services.AddSingleton<PlayersProcessor>();
            services.AddSingleton<ItemsProcessor>();
            services.AddSingleton<ApiKey>(new ApiKey(Configuration.GetValue<string>("api-key"), Configuration.GetValue<string>("api-key-admin")));

            services.AddMvc(options =>
            {
                options.Filters.Add(new LowLevelPlayerExceptionFilterAttribute()); // custom filter - applies to all controllers and their actions
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            /*
                        services.AddAuthorization(options =>
                        {
                            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                            options.AddPolicy("Admin", policy => policy.RequireRole("User"));
                            options.DefaultPolicy = options.
                            
                        });        }
            */
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();

            //AuthMiddleware.api_key = Configuration.GetValue<string>("api-key");
        }
    }
}