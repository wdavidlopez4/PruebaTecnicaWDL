using Microsoft.Extensions.Configuration;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Infrastructure.Employees
{
    public class EmployeesRepositorySQLServerDONET : IEmployeeRepository
    {
        private const string NAME_PROCEDURE = "EmployeeProcedure";

        private readonly string connectionString;

        public EmployeesRepositorySQLServerDONET(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("CoffeeConnectionString");
        }

        public async Task<Employee> Get(string id)
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 1));
            cmd.Parameters.Add(new SqlParameter("@Id", int.Parse(id)));

            Employee response = null;
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response = MapToValue(reader);
                }
            }

            return response;
        }

        public async Task<List<Employee>> GetAll()
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 2));

            var response = new List<Employee>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(MapToValue(reader));
                }
            }

            return response;
        }

        public async Task Save(Employee employee)
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 3));
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id.Value));
            cmd.Parameters.Add(new SqlParameter("@Nombre", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@Apellido", employee.LastName));
            cmd.Parameters.Add(new SqlParameter("@Telefono", employee.CellPhone));
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", employee.Date));
            await sql.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return;
        }

        public async Task Update(Employee employee)
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 4));
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id.Value));
            cmd.Parameters.Add(new SqlParameter("@Nombre", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@Apellido", employee.LastName));
            cmd.Parameters.Add(new SqlParameter("@Telefono", employee.CellPhone));
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", employee.Date));
            await sql.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return;
        }

        private static Employee MapToValue(SqlDataReader reader)
        {
            return Employee.Build(
                id: new EmployeeId((int) reader["Id"]), 
                name: (string) reader["Nombre"],
                lastName: (string)reader["Apellido"],
                date: (string)reader["FechaNacimiento"],
                cellPhone: (string)reader["Telefoo"]);
        }
    }
}
