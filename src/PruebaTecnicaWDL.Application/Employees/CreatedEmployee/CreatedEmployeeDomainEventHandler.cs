using pmilet.DomainEvents;
using PruebaTecnicaWDL.Domain.Employees;
using PruebaTecnicaWDL.Domain.Orders.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.CreatedEmployee
{
    public class CreatedEmployeeDomainEventHandler : HandleDomainEventsBase<OrderCreatedDomainEvent>
    {
        private readonly IEmployeeRepository repository;

        public CreatedEmployeeDomainEventHandler(IDomainEventDispatcher dispatcher, IEmployeeRepository repository) 
            : base(dispatcher)
        {
            this.repository = repository;
        }

        public override void HandleEvent(OrderCreatedDomainEvent domainEvent)
        {
            if (this.repository.Get(domainEvent.EmployeeId.Value.ToString()) == null)
                throw new ArgumentException("El enpleado no existe");
        }
    }
}
