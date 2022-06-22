using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.GetAllEmployee
{
    public class GetEmployeeQuery : IRequest<List<GetEmployeeDTO>>
    {
        //objecto de query limpio
    }
}
