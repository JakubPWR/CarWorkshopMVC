using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>
    {
        private readonly IMapper _mapper;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        public GetCarWorkshopByEncodedNameQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);
            var carWorkshopDto = _mapper.Map<CarWorkshopDto>(carWorkshop);
            return carWorkshopDto;
        }
    }
}
