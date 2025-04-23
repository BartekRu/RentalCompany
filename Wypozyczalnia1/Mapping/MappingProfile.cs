using AutoMapper;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.Mapping
{
    /*public class MappingProfile
    {
    }*/
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationViewModel>().ReverseMap();
        }
    }
}
