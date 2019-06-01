using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CloudApi;
using CloudApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebAPIApplication;
using Microsoft.AspNetCore.Authorization;

namespace CloudApi
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
            string domain = $"https://{Configuration["Auth0:Domain"]}/";

            services.AddDbContext<LibraryContext>(
               options => options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")
                   )
             );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; }
            ).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-d0xsb9au.eu.auth0.com/";
                options.Audience = "https://localhost:5001/api/v1";
                options.RequireHttpsMetadata = false ;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:animals", policy => policy.Requirements.Add(new HasScopeRequirement("write:animals", domain)));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:animals", policy => policy.Requirements.Add(new HasScopeRequirement("read:animals", domain)));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:families", policy => policy.Requirements.Add(new HasScopeRequirement("read:families", domain)));
            });
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,LibraryContext libContext )
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
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
                //template: "{controller=Home}/{action=Index}/{id?}");
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

            DBInitializer.Initialize(libContext);
        }
    }
}
