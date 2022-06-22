using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.SelectEmployee
{
    public class SelectEmployeeQuery : IRequest<SelectEmployeeDTO>
    {
        public int EmployeeId { get; private set; }

        public SelectEmployeeQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
