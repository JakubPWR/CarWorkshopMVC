using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopsByNameList;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCarWorkshopCommand));
            services.AddMediatR(typeof(GetAllCarWorkshopsQuery));
            services.AddMediatR(typeof(GetCarWorkshopsByNameListQuery));
            services.AddMediatR(typeof(EditCarWorkshopCommand));

            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<EditCarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
