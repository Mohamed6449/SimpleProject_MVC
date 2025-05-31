using AutoMapper;
using MCV_Empity.Models;
using MCV_Empity.ViewModels;

namespace MCV_Empity.Mapping
{
	public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<AddProductViewModels, product>();

		}
	}
}
