using AutoMapper;
using PruebaTecnicaWDL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Infrastructure.Startup
{
    public class MapObject : IMapObject
    {
        private readonly IMapper mapper;

        public MapObject(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            try
            {
                return mapper.Map<TSource, TDestination>(source);
            }
            catch (Exception e)
            {

                throw new Exception($"{e.Message}");
            }
        }
    }
}
