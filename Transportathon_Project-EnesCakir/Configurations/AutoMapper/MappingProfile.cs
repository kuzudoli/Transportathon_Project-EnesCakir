using AutoMapper;
using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models;
using Transportathon_Project_EnesCakir.Models.ViewModels;

namespace Transportathon_Project_EnesCakir.Configurations.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyWithEmployeeCount, CompanyViewModel>();
            CreateMap<Company, CompanyViewModel>();

            CreateMap<CreateRequestViewModel, Request>();
            CreateMap<Request, EditRequestViewModel>();

            CreateMap<AppUser, EditUserViewModel>();
        }
    }
}