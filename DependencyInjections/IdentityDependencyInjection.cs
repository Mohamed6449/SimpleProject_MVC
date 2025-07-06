using MCV_Empity.Data;
using Microsoft.AspNetCore.Identity;

namespace MCV_Empity.DependencyInjections
{
    public static class IdentityDependencyInjection
    {
        public static IServiceCollection AddIdentityDependencyInjection(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores < AppDbContect>() ;



            return services;
        }

    }
}
