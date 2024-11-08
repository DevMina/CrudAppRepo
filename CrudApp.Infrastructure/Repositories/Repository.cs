using CrudApp.Core.Interfaces;
using CrudApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CrudDbContext _context;

        public Repository(CrudDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}
