using pmilet.DomainEvents;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain.Orders.Events
{
    public class OrderCreatedDomainEvent : DomainEvent
    {
        public OrderId Id { get; private set; }

        public EmployeeId EmployeeId { get; private set; }

        public int Detail { get; private set; }

        public OrderCreatedDomainEvent(OrderId id, EmployeeId employeeId, int detail)
            : base("OrderCreatedDomainEvent", "1.0")
        {
            this.Id = id;
            this.EmployeeId = employeeId;
            this.Detail = detail;

        }
    }
}
