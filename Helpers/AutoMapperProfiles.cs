using AutoMapper;
using JobSearchTracker.Models;
using JobSearchTracker.Models.Dtos;

namespace JobSearchTracker.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles() {
			CreateMap<AppUser, UserInfoDTO>();
			CreateMap<Jobs, JobsDto>();
		}
	}
}
