using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopsByNameList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController: Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarWorkshopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
            return View(carWorkshops);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction("Index"); //TODO refactor
        }
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            var carWorkshops = await _mediator.Send(new GetCarWorkshopsByNameListQuery(name));
            if(!carWorkshops.Any())
            {
                ViewBag.Message = "No car workshops found.";
                return View();
            }
            return View("SearchResults",carWorkshops);
        }
        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var carWorkshop = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            EditCarWorkshopCommand model = _mapper.Map<EditCarWorkshopCommand>(carWorkshop);
            return View(model);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditCarWorkshopCommand command, string encodedName)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //TODO refactor
        }
    }
}
