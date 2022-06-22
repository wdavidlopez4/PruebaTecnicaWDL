using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaWDL.Application.Employees.CreateEmployee;
using PruebaTecnicaWDL.Application.Employees.GetAllEmployee;
using PruebaTecnicaWDL.Application.Employees.ModifyEmployee;
using PruebaTecnicaWDL.Application.Employees.SelectEmployee;
using PruebaTecnicaWDL.Application.Orders.AddOrder;
using PruebaTecnicaWDL.Domain;
using PruebaTecnicaWDL.Domain.Employees;
using PruebaTecnicaWDL.Domain.Orders;
using PruebaTecnicaWDL.Infrastructure.Employees;
using PruebaTecnicaWDL.Infrastructure.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Infrastructure.Startup
{
    public class PruebaTecnicaWDLStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureIOC(services);
            ConfigureMediador(services);
            ConfigureMapper(services);
        }

        private static void ConfigureIOC(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeesRepositorySQLServerDONET>();
            services.AddScoped<IOrderRepository, OrderRepositorySQLServerDONET>();
            services.AddScoped<IMapObject, MapObject>();
        }

        private static void ConfigureMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(GetEmployeeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetEmployeeQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ModifyEmployeeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SelectEmployeeQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddOrderCommand).GetTypeInfo().Assembly);
        }

        private static void ConfigureMapper(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
