using MediatR;
using PruebaTecnicaWDL.Domain;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.SelectEmployee
{
    public class SelectEmployeeHandler : IRequestHandler<SelectEmployeeQuery, SelectEmployeeDTO>
    {
        private readonly IEmployeeRepository repository;

        private readonly IMapObject mapObject;

        public SelectEmployeeHandler(IEmployeeRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<SelectEmployeeDTO> Handle(SelectEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await this.repository.Get(request.EmployeeId.ToString());
            return mapObject.Map<Employee, SelectEmployeeDTO>(employee);
        }
    }
}
