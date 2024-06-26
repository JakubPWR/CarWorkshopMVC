﻿using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.Mappings;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
            _carWorkshopRespository = carWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();
            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;
            await _carWorkshopRespository.Create(carWorkshop);
            return Unit.Value;
        }
    }
}
