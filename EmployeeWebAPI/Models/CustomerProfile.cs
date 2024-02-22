using AutoMapper;

namespace EmployeeWebAPI.Models
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerSource, CustomerDestination>()
                                                            .ForMember("Id",opt=>opt.MapFrom("CustId"))
                                                            .ForMember("Name",opt=>opt.MapFrom("CustName"));
        }
    }
}
