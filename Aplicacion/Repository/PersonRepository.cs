using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    private readonly IncidenceContext _context;
    public PersonRepository(IncidenceContext context) : base(context)
    {
        _context = context;
    }
     public override async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.Persons.Include(p => p.Incidences)
        .ToListAsync();
    }
}