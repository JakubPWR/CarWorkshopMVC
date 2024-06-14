using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Description)
               .NotEmpty().WithMessage("Please enter description");
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone number can not be empty")
                .MinimumLength(8).WithMessage("Phone number must have minimal length of 8 numbers")
                .MaximumLength(12).WithMessage("Phone number must have maximum length of 12 numbers");
        }
    }
}
