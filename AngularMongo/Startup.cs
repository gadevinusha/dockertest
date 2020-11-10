using DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AngularMongo
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
            services.AddControllersWithViews();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            //below lines for azure ad authentication
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme).AddAzureADBearer(options => Configuration.Bind("AzureActiveDirectory", options));
            string corsDomains = "http://localhost:4200,https://localhost:44373/";
            string[] domains = corsDomains.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            services.AddCors(o => o.AddPolicy("AppCORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithOrigins(domains);
            }));
            //end azure ad

            //below commented line is for basic web api autehtication which needs username and password to be sent
            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicWebAPIAuthenticationHandler>("BasicAuthentication", null);
            services.AddSingleton(typeof(IWorkOrderOperations), typeof(WorkOrderOperations));
            services.AddSingleton(typeof(WorkorderTasks));
            services.AddSingleton(typeof(SecurityService));

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            //added for azure ad
            app.UseCors("AppCORSPolicy");
            //end azure ad
            //commented for azure ad, uncomment if not using azure ad, applies all urls to access this web ap[i application
            //app.UseCors(builder => builder
            //  .AllowAnyHeader()
            //  .AllowAnyMethod()
            //  .SetIsOriginAllowed((host) => true)
            //  .AllowCredentials()
            //  );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
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


            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseCors("CorsPolicy");
        }
    }

    public class BasicWebAPIAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly SecurityService _service;

        public BasicWebAPIAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            SecurityService userService)
            : base(options, logger, encoder, clock)
        {
            _service = userService;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var header = Request.Headers;
            if (!header.ContainsKey("Authorization"))
            {
                //actionContext.Response = Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                return AuthenticateResult.Fail("Missing Authorization Header");
            }
            else
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var autheniticationToken = authHeader.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(autheniticationToken));
                string[] array = decodedAuthenticationToken.Split(':');
                string username = array[0];
                string password = array[1];
                SecurityService _ldapService = new SecurityService();
                var result = await _ldapService.Authenticate(username, password);
                if (result)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(decodedAuthenticationToken), null);
                    var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    new Claim(ClaimTypes.Name, username),
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                   return AuthenticateResult.Fail("User is not Unauthorized");
                }
            }
        }
    }

}
