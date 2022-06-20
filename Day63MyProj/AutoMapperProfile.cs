using AutoMapper;
using Day63MyProj.Data.Models;
using Day63MyProj.Models.ViewModel;

namespace Day63MyProj
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }
    }
}
