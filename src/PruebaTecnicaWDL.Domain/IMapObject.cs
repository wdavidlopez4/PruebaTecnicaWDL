using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain
{
    public interface IMapObject
    {
        public TDestination Map<TSourse, TDestination>(TSourse sourse);
    }
}
