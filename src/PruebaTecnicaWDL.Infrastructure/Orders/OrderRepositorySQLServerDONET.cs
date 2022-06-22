using Microsoft.Extensions.Configuration;
using PruebaTecnicaWDL.Domain.Employees;
using PruebaTecnicaWDL.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Infrastructure.Orders
{
    public class OrderRepositorySQLServerDONET : IOrderRepository
    {
        private const string NAME_PROCEDURE = "OrderProcedure";

        private readonly string connectionString;

        public OrderRepositorySQLServerDONET(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("CoffeeConnectionString");
        }

        public async Task<Order> Get(string id)
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            cmd.Parameters.Add(new SqlParameter("@operation", 0));

            Order response = null;
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

        public async Task<List<Order>> GetAll()
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 1));

            var response = new List<Order>();
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

        public async Task Save(Order employee)
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 2));
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id));
            cmd.Parameters.Add(new SqlParameter("@EmpleadoID", employee.EmployeeId));
            cmd.Parameters.Add(new SqlParameter("@DetallerOrdenes", employee.Detail));

            await sql.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return;
        }

        public async Task Update(Order employee)
        {
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(NAME_PROCEDURE, sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@operation", 3));
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id));
            cmd.Parameters.Add(new SqlParameter("@EmpleadoID", employee.EmployeeId));
            cmd.Parameters.Add(new SqlParameter("@DetallerOrdenes", employee.Detail));

            await sql.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return;
        }

        private static Order MapToValue(SqlDataReader reader)
        {
            return Order.Build(
                id: new OrderId((int)reader["Id"]),
                employeeId: new EmployeeId((int)reader["EmpleadoID"]),
                detail: (int)reader["DetallerOrdenes"]);
        }
    }
}
