using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopsByNameList
{
    public class GetCarWorkshopsByNameListQuery : IRequest<IEnumerable<CarWorkshopDto>>
    {
        public string? Name { get; set; }
        public GetCarWorkshopsByNameListQuery(string name)
        {
            Name = name;
        }
    }
}
