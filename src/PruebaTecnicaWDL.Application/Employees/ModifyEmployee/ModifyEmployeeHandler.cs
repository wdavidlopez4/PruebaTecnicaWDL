using MediatR;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.ModifyEmployee
{
    public class ModifyEmployeeHandler : IRequestHandler<ModifyEmployeeCommand, int>
    {
        private readonly IEmployeeRepository employeeRepository;

        public ModifyEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(ModifyEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employer = await this.employeeRepository.Get(request.Id.ToString());
            employer.ChangeMainAttribute(
                name: request.Name, 
                lastName: request.LastName, 
                date: request.Date, 
                cellPhone: request.CellPhone);

            await this.employeeRepository.Update(employer);
            return 0;
        }
    }
}
