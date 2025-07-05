using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;

namespace MCV_Empity.DependencyInjections
{
    public static class ServiceDependencyInjection
    {


        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection Services)
        {

            Services.AddTransient<IProductService, ProductService>();


            Services.AddTransient<ICategoryServices, CategoryServices>();

            
            Services.AddTransient<IFileServiece, FileServices>();
            
            
            return Services;

        }
    }
}
