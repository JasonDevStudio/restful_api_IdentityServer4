using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace web_api_docker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. Bearer
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               .AddInMemoryClients(ApiConfig.GetClients())
               .AddInMemoryApiResources(ApiConfig.GetApiResources()); ;
             
            var identityServerOptions = new IdentityServerOptions() {};
            Configuration.Bind("IdentityServerOptions", identityServerOptions);
            services.AddAuthentication("Basic")
                .AddIdentityServerAuthentication(options =>
                {
                    options.RequireHttpsMetadata = false; //是否启用https
                    options.Authority = $"http://localhost:8090";//配置授权认证的地址 
                    options.ApiName = "UserApi"; //资源名称，跟认证服务中注册的资源列表名称中的apiResource一致
                }
                );
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseHttpsRedirection();

            //添加认证中间件
            app.UseIdentityServer();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
