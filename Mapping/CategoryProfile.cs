using AutoMapper;
using MCV_Empity.Models;
using MCV_Empity.ViewModels.Categories;

namespace MCV_Empity.Mapping
{
	public class CategoryProfile:Profile
	{
		public CategoryProfile() {

			CreateMap<Category, GetCategoriesListViewModel>().ForMember(F => F.Name, Option => Option.
	MapFrom(M => M.Localize(M.NameAr, M.NameEn)));

			CreateMap<Category, GetCategoryByIdViewModel>();
			CreateMap<Category, UpdateCategoryViewModel>();
			CreateMap<AddCategoryViewModel,Category>();
		}
	}
}
