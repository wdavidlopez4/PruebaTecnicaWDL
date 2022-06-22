using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Orders.AddOrder
{
    public class AddOrderCommand :IRequest<int>
    {
        public int Id { get; private set; }

        public int EmployeeId { get; private set; }

        public int Detail { get; private set; }

        public AddOrderCommand(int id, int employeeId, int detail)
        {
            Id = id;
            EmployeeId = employeeId;
            Detail = detail;
        }
    }
}
