using AutoMapper;
using MCV_Empity.Models.Identity;
using MCV_Empity.ViewModels.Claims;
using MCV_Empity.ViewModels.Identity.Users;

namespace MCV_Empity.Mapping
{
	public class ClaimProfile:Profile
	{
		public ClaimProfile()
		{
			CreateMap<Claim, GetClaimsViewModel>().
				ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn))) ;
			CreateMap<AddClaimViewModel, Claim>();

		}
	}
}
