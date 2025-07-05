using AutoMapper;
using MCV_Empity.Models;
using MCV_Empity.ViewModels.Categories;
using MCV_Empity.ViewModels.Products;

namespace MCV_Empity.Mapping
{
    public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<AddProductViewModels, product>();
			CreateMap<product, GetProductListViewModel>().
			ForMember(des => des.Name, option => option.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
			CreateMap<product, UpdateProductViewModel>().ForMember(des=>des.CurrentPaths,
				option=>option.MapFrom(src=>src.ProductImages.Select(s=>s.path).ToList()));
			CreateMap<UpdateProductViewModel, product>();


		}
	}
}
