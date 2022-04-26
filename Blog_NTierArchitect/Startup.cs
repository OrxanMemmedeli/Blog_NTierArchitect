﻿using Blog_NTierArchitect.IdentityLabrery;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect
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
            services.AddDbContext<BlogContext>();
            services.AddIdentity<AppUser, AppRole>(x => {
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 5; //min simvol sayi
                x.User.RequireUniqueEmail = true; //emailin uniq olmasi

            })
                .AddErrorDescriber<TranslateErrorMessage>()
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<BlogContext>();
            services.Register();

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Account/Login");
                _.LogoutPath = new PathString("/Account/LogOut");
                _.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityExampleCookie", //Olusturulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //Kotu niyetli insanlarin client-side tarafindan Cookie'ye erismesini engelliyoruz.
                    //Expiration = TimeSpan.FromMinutes(180), //Olusturulacak Cookie'nin vadesini belirliyoruz.
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gonderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS uzerinden erisilebilir yapiyoruz.
                };
                _.SlidingExpiration = true; //Expiration suresinin yarisi kadar sure zarfinda istekte bulunulursa eğer geri kalan yarisini tekrar sifirlayarak ilk ayarlanan sureyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(120); //CookieBuilder nesnesinde tanimlanan Expiration degerinin varsayilan degerlerle ezilme ihtimaline karsin tekrardan Cookie vadesi burada da belirtiliyor.
            });

            services.AddControllersWithViews().AddFluentValidation();
            services.Validators();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                o.LoginPath = "/Account/Login";
                o.LogoutPath = "/Account/LogOut";
                o.AccessDeniedPath = "/Account/AccessDenied"; //Role uygun olmadiqda yonelmeni temin edecekdir.
                o.SlidingExpiration = true;
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireRole("Admin, Manager, Writer, User")
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            }); // all controller check for login 
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseStatusCodePages(); // Ag sehifede error kodunu yazmaq
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Index", "?code{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area}/{controller=Blog}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
