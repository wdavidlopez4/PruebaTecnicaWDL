using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Application.Employees.CreateEmployee
{
    public class GetEmployeeCommand : IRequest<int>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Date { get; private set; }

        public string CellPhone { get; private set; }

        public GetEmployeeCommand(int id, string name, string lastName, string date, string cellPhone)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Date = date;
            CellPhone = cellPhone;
        }
    }
}
