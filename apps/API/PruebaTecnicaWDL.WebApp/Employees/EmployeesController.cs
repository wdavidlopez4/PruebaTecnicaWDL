using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaWDL.Application.Employees.CreateEmployee;
using PruebaTecnicaWDL.Application.Employees.GetAllEmployee;
using PruebaTecnicaWDL.Application.Employees.ModifyEmployee;
using PruebaTecnicaWDL.Application.Employees.SelectEmployee;

namespace PruebaTecnicaWDL.WebApi.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Put(PutEmployeeRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new GetEmployeeCommand(request.Id, request.Name, request.LastName, request.Date, request.CellPhone);

            var dto = await mediator.Send(command);

            return Ok(dto);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(GetEmployeeRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new SelectEmployeeQuery(request.EmployeeId);

            var dto = await mediator.Send(command);

            return Ok(dto);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new GetEmployeeQuery();

            var dto = await mediator.Send(command);

            return Ok(dto);
        }

        [HttpPost]
        [Route("modify")]
        public async Task<IActionResult> Modify(ModifyEmployeeRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new ModifyEmployeeCommand(request.Id, request.Name, request.LastName, request.Date, request.CellPhone);

            var dto = await mediator.Send(command);

            return Ok(dto);
        }
    }
}
