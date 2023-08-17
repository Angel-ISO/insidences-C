using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system.Linq.Expressions;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    public RolRepository (IncidenceContext context) : base(context)
    {
    }
}
