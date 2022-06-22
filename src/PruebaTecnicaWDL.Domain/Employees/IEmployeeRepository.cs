using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain.Employees
{
    public interface IEmployeeRepository
    {
        public Task<Employee> Get(string id);

        public Task<List<Employee>> GetAll();

        public Task Save(Employee employee);

        public Task Update(Employee employee);
    }
}
