using MediatR;
using PruebaTecnicaWDL.Domain;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<GetEmployeeCommand, int>
    {
        private readonly IEmployeeRepository employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(GetEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee;

            employee = Employee.Build(
                id: new EmployeeId(request.Id), 
                name: request.Name, 
                lastName : request.LastName, 
                date: request.Date, 
                cellPhone: request.CellPhone);

            await this.employeeRepository.Save(employee);

            return 0;
        }
    }
}
