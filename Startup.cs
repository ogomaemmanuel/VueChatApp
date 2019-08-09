using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using VueChatApp.Data;
using VueChatApp.Features.AccessControl.Entities;
using VueChatApp.Features.Chat.Services;
using VueChatApp.Features.Documents.Buckets.Services;
using VueChatApp.Features.DocumentsManager.Documents.Services;
using VueChatApp.Features.QrCode;
using VueChatApp.Hubs;
using VueChatApp.Services.CloudStorage;
using VueChatApp.Utils;

namespace VueChatApp
{
    public class Startup
    {
        private IHostingEnvironment _appEnv;

        public Startup(IConfiguration configuration,IHostingEnvironment appEnv)
        {
            Configuration = configuration;
            _appEnv = appEnv;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSignalR();
            services.AddScoped<VideoConverter>();
            services.AddScoped<IQrCodeGeneratorService,QrCodeGeneratorService>();
            services.AddAWSService<IAmazonS3>();
            services.AddScoped<ICloudStorageService, S3StorageService>();
            services.AddScoped<IBucketService, BucketService>();
            services.AddScoped<IDocumentService, DocumentService>();
             services.AddDbContext<ChatDbContext>(options =>
options.UseSqlite($"Data Source={_appEnv.WebRootPath}/ChatTutorial.db"));
            services.AddHttpClient<IChatService, ChatService>();
            services.AddNodeServices();
            services.AddIdentity<SystemUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ChatDbContext>()
           .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = Configuration["Jwt:Issuer"],
              ValidAudience = Configuration["Jwt:Issuer"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
          options.Events = new JwtBearerEvents
          {
              OnMessageReceived = context =>
              {
                  if (context.Request.Path.Value.StartsWith("/signalr/notification-hub") &&
                      context.Request.Query.TryGetValue("token", out StringValues token)
                  )
                  {
                      context.Token = token;
                  }

                  return Task.CompletedTask;
              },
              OnAuthenticationFailed = context =>
              {
                  var te = context.Exception;
                  return Task.CompletedTask;
              }
          };
      });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/signalr/notification-hub");
                routes.MapHub<QrLoginHub>("/login-hub");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
