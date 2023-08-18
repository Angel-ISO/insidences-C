using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class TypeIncidenceRepository : GenericRepository<TypeIncidence>, ITypeIncidenceRepository
{
    public TypeIncidenceRepository(IncidenceContext context) : base(context)
    {
        
    }
}