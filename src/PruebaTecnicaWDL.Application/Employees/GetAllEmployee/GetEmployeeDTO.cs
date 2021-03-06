using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.GetAllEmployee
{
    public class GetEmployeeDTO
    {
        /// <summary>
        /// no se retorna el objeto sino el valor
        /// </summary>
        public EmployeeId Id { get;  set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Date { get; set; }

        public string CellPhone { get; set; }
    }
}
