using MediatR;
using PruebaTecnicaWDL.Domain.Employees;
using PruebaTecnicaWDL.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Orders.AddOrder
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IOrderRepository repository;

        public AddOrderHandler(IOrderRepository orderRepository)
        {
            this.repository = orderRepository;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Build(
                id: new OrderId(request.Id), 
                employeeId: new EmployeeId(request.EmployeeId), 
                detail: request.Detail);

            await this.repository.Save(order);
            return 0;
        }
    }
}
