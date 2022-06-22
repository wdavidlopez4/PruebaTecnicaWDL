using MediatR;
using PruebaTecnicaWDL.Domain;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.GetAllEmployee
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, List<GetEmployeeDTO>>
    {
        private readonly IEmployeeRepository repository;

        private readonly IMapObject mapObject;

        public GetEmployeeHandler(IEmployeeRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetEmployeeDTO>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            List<Employee> employees = await this.repository.GetAll();
            return mapObject.Map<List<Employee>, List<GetEmployeeDTO>>(employees);
        }
    }
}
