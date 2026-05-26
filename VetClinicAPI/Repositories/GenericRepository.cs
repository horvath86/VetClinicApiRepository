
using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Data;
using VetClinicAPI.Models;

namespace VetClinicAPI.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T item) 
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "Animal cannot be null");

            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var itemInDB = await _context.Set<T>().FindAsync(id);

            if (itemInDB == null)
            {
                throw new KeyNotFoundException($"Animal with {id} was not found");
            }

            _context.Set<T>().Remove(itemInDB);
            await _context.SaveChangesAsync();
        }
    }
}
