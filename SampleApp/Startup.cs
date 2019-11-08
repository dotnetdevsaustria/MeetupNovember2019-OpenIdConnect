using System.IdentityModel.Tokens.Jwt;
using BIF4DotNetDemo.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BIF4DotNetDemo
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
            services.AddDbContextPool<ToDoDbContext>(
                options => options.UseSqlite("DataSource=todo.db")
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            
            // remove default OId->WS-Fed mappings since we don't need legacy claim IDs
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://bif4-web-identity.azurewebsites.net/";
                    options.Audience = "ue5-api";
                    options.RequireHttpsMetadata = false;
                    options.IncludeErrorDetails = true;
                    options.SaveToken = true;
                });

            services.AddAuthorization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseXfo(options => options.SameOrigin());
            
            app.UseCsp(config => {
                config.DefaultSources(cfg => cfg.Self())
                .ScriptSources(cfg => cfg.Self().UnsafeEval())
                .StyleSources(cfg => cfg.Self().UnsafeInline())
                .FontSources(cfg => cfg.Self())
                .ImageSources(cfg => cfg.Self().CustomSources("data:"))
                .FrameSources(cfg => cfg.Self().CustomSources("https://bif4-web-identity.azurewebsites.net"))
                .MediaSources(cfg => cfg.None())
                .FrameAncestors(cfg => cfg.None());

                if (env.IsDevelopment()) {
                    // webpack needs websocket but ws:// urls aren't covered under "self" policy
                    config.ConnectSources(cfg => cfg.CustomSources("*"));
                } else {
                    config.ConnectSources(cfg => cfg.Self().CustomSources("https://bif4-web-identity.azurewebsites.net"));
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                HstsBuilderExtensions.UseHsts(app);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
