using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRespository;
        public EditCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRespository = carWorkshopRepository;
        }
        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRespository.GetByEncodedName(request.EncodedName);
            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;
            carWorkshop.ContactDetails.Street = request.Street;
            await _carWorkshopRespository.Commit();
            return Unit.Value;
        }
    }
}
