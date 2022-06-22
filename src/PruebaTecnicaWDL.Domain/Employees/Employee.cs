using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain.Employees
{
    public class Employee : Aggregate
    {
        public EmployeeId Id { get; private set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Date { get; private set; }

        public string CellPhone { get; private set; }


        private Employee(EmployeeId id, string name, string lastName, string date, string cellPhone):base()
        {
            if(id is null)
                throw new ArgumentNullException("id");
            else if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            else if (String.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lashtmane");
            else if (String.IsNullOrEmpty(date))
                throw new ArgumentNullException("date");
            else if (String.IsNullOrEmpty(cellPhone))
                throw new ArgumentNullException("cell");

            Id = id;
            Name = name;
            LastName = lastName;
            Date = date;
            CellPhone = cellPhone;
        }

        public static Employee Build(EmployeeId id, string name, string lastName, string date, string cellPhone)
        {
            return new Employee(id, name, lastName, date, cellPhone);
        }

        public void ChangeMainAttribute(string name, string lastName, string date, string cellPhone)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            else if (String.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lashtmane");
            else if (String.IsNullOrEmpty(date))
                throw new ArgumentNullException("date");
            else if (String.IsNullOrEmpty(cellPhone))
                throw new ArgumentNullException("cell");

            Name = name;
            LastName = lastName;
            Date = date;
            CellPhone = cellPhone;
        }
    }
}
