using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaWDL.Application.Employees.GetAllEmployee;
using PruebaTecnicaWDL.Application.Employees.ModifyEmployee;
using PruebaTecnicaWDL.WebApp.Models;
using System.Diagnostics;

namespace PruebaTecnicaWDL.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMediator mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var command = new GetEmployeeQuery();

            var dto = await mediator.Send(command);

            return View(dto);
        }

        public IActionResult Modificar(string idEmployee)
        {
            TempData["IdCategoria"] = idEmployee;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(EmployeeVM vM)
        {
            var id = TempData["IdCategoria"].ToString();
            var command = new ModifyEmployeeCommand(int.Parse(id), vM.Name, vM.LastName, vM.Date, vM.CellPhone);

            _ = await mediator.Send(command);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}