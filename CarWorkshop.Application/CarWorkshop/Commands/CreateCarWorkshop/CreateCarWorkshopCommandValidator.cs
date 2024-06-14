using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .MinimumLength(2).WithMessage("Name must be longer than 2 characters")
                .MaximumLength(20)
                .WithMessage("Name can not be longer than 20 characters")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                });
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone number can not be empty")
                .MinimumLength(8).WithMessage("Phone number must have minimal length of 8 numbers")
                .MaximumLength(12).WithMessage("Phone number must have maximum length of 12 numbers");
        }
    }
}
