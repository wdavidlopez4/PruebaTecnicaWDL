using pmilet.DomainEvents;
using PruebaTecnicaWDL.Domain.Employees;
using PruebaTecnicaWDL.Domain.Orders.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain.Orders
{
    public class Order : Aggregate
    {
        public OrderId Id { get; private set; }

        public EmployeeId EmployeeId { get; private set; }

        public int Detail { get; private set; }

        private Order(OrderId id, EmployeeId employeeId, int detail):base()
        {
            if (id == null)
                throw new ArgumentNullException("id");
            else if (employeeId == null)
                throw new ArgumentNullException("id");
            else if (detail < 0)
                throw new ArgumentOutOfRangeException("detail");

            Id = id;
            EmployeeId = employeeId;
            Detail = detail;

            //publicar evento de dominio
            this.dispatcher.Publish<OrderCreatedDomainEvent>(new OrderCreatedDomainEvent(id, employeeId, detail));
        }

        public static Order Build(OrderId id, EmployeeId employeeId, int detail)
        {
            return new Order(id, employeeId, detail);
        }

        public void ChangeMainAttribute(int detail)
        {
            Detail = detail;
        }
    }
}
