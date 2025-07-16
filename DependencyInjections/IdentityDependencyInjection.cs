﻿using MCV_Empity.Data;
using MCV_Empity.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace MCV_Empity.DependencyInjections
{
    public static class IdentityDependencyInjection
    {
        public static IServiceCollection AddIdentityDependencyInjection(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(Opt=> {
                Opt.Password.RequireDigit = true;
                Opt.Password.RequireLowercase = true;
                Opt.Password.RequireUppercase = true;
                Opt.Password.RequireNonAlphanumeric= true;
                Opt.Password.RequiredLength=6;



                Opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                Opt.Lockout.MaxFailedAccessAttempts = 3;
                Opt.Lockout.AllowedForNewUsers = true;

                //user sitting
                Opt.User.RequireUniqueEmail = true;


                Opt.SignIn.RequireConfirmedPhoneNumber = false;
                Opt.SignIn.RequireConfirmedEmail = false;
                
                })
                .AddEntityFrameworkStores<AppDbContect>()
                .AddDefaultTokenProviders() ;

            services.AddAuthorization(options =>
            options.AddPolicy("CreateProduct",policy=>policy.
            RequireAssertion(context=>context.User.IsInRole("Admin")&& context.User.HasClaim("Create Product","True"))

            )) ;



			return services;
        }

    }
}
