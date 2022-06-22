using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain.Orders
{
    public class OrderId : IntValueObject
    {
        public OrderId(int value) : base(value)
        {
        }
    }
}
