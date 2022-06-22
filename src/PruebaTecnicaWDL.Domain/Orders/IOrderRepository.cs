using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain.Orders
{
    public interface IOrderRepository
    {
        public Task Save(Order employee);
    }
}
