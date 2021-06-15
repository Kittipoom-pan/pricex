
using Api.Pricex.Configuration;
using Api.Pricex.Interface;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo;
using Api.Pricex.Repo.Admin;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;

namespace Api.Pricex
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
            services.AddCors();

            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            var emailConfig = Configuration
                        .GetSection("EmailConfiguration")
                        .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.Configure<EmailAccount>(Configuration.GetSection("EmailAccount"));

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IPushNotificationService, PushNotificationServiceRepo>();
            services.AddTransient<IOfferPayment, OfferPaymentRepo>();
            services.AddTransient<ILocation, LocationRepo>();
            services.AddTransient<IUserGroup, UserGroupRepo>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<pedb_devContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            //services.AddAuthentication(options => {
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(jwt => {
            //    var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

            //    jwt.SaveToken = true;
            //    jwt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
            //        IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        RequireExpirationTime = false,
            //        ValidateLifetime = true
            //    };
            //});

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //                .AddEntityFrameworkStores<pedb_devContext>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        // Validate JWT จาก appsetiings
            //        ValidateIssuer = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidateAudience = true,
            //        ValidAudience = Configuration["Jwt:Audience"],
            //        ValidateLifetime = true, // ExpireDay
            //        ClockSkew = TimeSpan.Zero, // disable delay when token is expire
            //        ValidateIssuerSigningKey = true, // Key
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});

            services.AddApiVersioning();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<Repo.Admin.DashboardRepo>();
            services.AddScoped<Repo.Admin.HotelInfoRepo>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseWebSockets();

            //app.UseMiddleware<ChatWebSocketMiddleware>();

            //app.MapSocket("/ws", serviceProvider.GetService<WebSocketMessageHandler>());

            app.UseCors(builder =>
            {
                //builder.WithOrigins("https://pricex-backoffice.feyverly-dev.com",
                //                    "https://pricex-backoffice-uat.feyverly-dev.com")
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"upload")),
                RequestPath = new PathString("/upload")
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication(); // ยืนยันตัวตน (ก่อนตรวจสอบสิทธิ์)

            app.UseAuthorization();

            app.UseFastReport();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
