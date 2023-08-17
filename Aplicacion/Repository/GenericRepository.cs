using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system.Linq.Expressions;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class GenericRepository <T> : IGenericRepository <T>  where T : BaseEntity
{
    private readonly IncidenceContext _context;

    public GenericRepository(IncidenceContext context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual void IEnumerable<T> Find(Expression <Func<T, bool>> expression);
    {
        return _context.Set<T>().Where(expression)
    }

    public virtual async  Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}