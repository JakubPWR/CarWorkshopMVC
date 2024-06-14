using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopsByNameList;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopsByNameList
{
    public class GetCarWorkshopsByNameListQueryHandler : IRequestHandler<GetCarWorkshopsByNameListQuery, IEnumerable<CarWorkshopDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        public GetCarWorkshopsByNameListQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetCarWorkshopsByNameListQuery request, CancellationToken cancellationToken)
        {
            var name = request.Name;
            if(string.IsNullOrEmpty(name))
            {
                var carWorkshops1 = await _carWorkshopRepository.GetAll();
                var carWorkshops1Dto = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops1);
                return carWorkshops1Dto;
            }
            var carWorkshops = await _carWorkshopRepository.GetByNameList(name);
            var carWorkshopsDto = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);
            return carWorkshopsDto;
        }
    }
}
