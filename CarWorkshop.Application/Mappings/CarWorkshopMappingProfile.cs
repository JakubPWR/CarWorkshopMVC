using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile: Profile 
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(c => c.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                { City = src.City,
                Street = src.City,
                PhoneNumber = src.PhoneNumber,
                PostalCode = src.PostalCode }));
            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(cd => cd.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(cd => cd.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(cd => cd.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(cd => cd.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));
            CreateMap<CarWorkshopDto,EditCarWorkshopCommand>();
        }
    }
}
