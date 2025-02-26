using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace ScheduleMasterServer
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<UserType, UserTypeDTO>();
        }
    }
}
