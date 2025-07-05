using MCV_Empity.Repository.implementation;
using MCV_Empity.Repository.Interface;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using MCV_Empity.SharedRepository;
using MCV_Empity.UnitOfWorks;

namespace MCV_Empity.DependencyInjections
{
    public static class RepositoryDependencyInjection
    {

        public static IServiceCollection AddRepositryDependencyInjection(this IServiceCollection Services)
        {
            Services.AddTransient<IProductRepository, ProductRepository>();

            Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            Services.AddTransient<IProductsImagesRepository, ProductsImagesRepository>();

            Services.AddTransient<ICategoryRepository, CategoryRepository>();

            Services.AddTransient<IUnitOfWork, UnitOfWork>();

            return Services;
             
        }
    }
}
