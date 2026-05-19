using Microsoft.EntityFrameworkCore;
using nз3.Data;

namespace nз3.Repositories
{
    /// <summary>
    /// Базовая реализация репозитория
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SchoolContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SchoolContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Получить все записи
        /// </summary>
        public async Task<IEnumerable<T>> GetAllAsync() => 
            await _dbSet.ToListAsync();
            
        /// <summary>
        /// Получить запись по ID
        /// </summary>
        public async Task<T> GetByIdAsync(int id) => 
            await _dbSet.FindAsync(id);
            
        /// <summary>
        /// Добавить новую запись
        /// </summary>
        public async Task AddAsync(T entity)
        { 
            await _dbSet.AddAsync(entity); 
            await _context.SaveChangesAsync(); 
        }
        
        /// <summary>
        /// Обновить запись
        /// </summary>
        public async Task UpdateAsync(T entity)
        { 
            _context.Update(entity); 
            await _context.SaveChangesAsync(); 
        }
        
        /// <summary>
        /// Удалить запись по ID
        /// </summary>
        public async Task DeleteAsync(int id)
        { 
            var entity = await _dbSet.FindAsync(id); 
            if(entity != null) 
            { 
                _dbSet.Remove(entity); 
                await _context.SaveChangesAsync(); 
            } 
        }
    }
}