using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaWDL.Application.Orders.AddOrder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaWDL.WebApi.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Put(PutOrderRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new AddOrderCommand(request.Id, request.EmployeeId, request.Detail);

            var dto = await mediator.Send(command);

            return Ok(dto);
        }
    }
}
