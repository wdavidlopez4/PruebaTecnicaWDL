using AutoMapper;
using PruebaTecnicaWDL.Application.Employees.GetAllEmployee;
using PruebaTecnicaWDL.Application.Employees.SelectEmployee;
using PruebaTecnicaWDL.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Infrastructure.Startup
{
    public class MapProfile : Profile
    {
        public MapProfile(): base()
        {
            this.CreateMap<Employee, GetEmployeeDTO>();
            this.CreateMap<Employee, SelectEmployeeDTO>();
        }
    }
}
