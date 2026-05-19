using System.Linq.Expressions;

namespace nз3.Repositories
{
    /// <summary>
    /// Общий интерфейс репозитория для работы с сущностями
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получить все сущности
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();
        
        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        Task<T> GetByIdAsync(int id);
        
        /// <summary>
        /// Добавить сущность
        /// </summary>
        Task AddAsync(T entity);
        
        /// <summary>
        /// Обновить сущность
        /// </summary>
        Task UpdateAsync(T entity);
        
        /// <summary>
        /// Удалить сущность по ID
        /// </summary>
        Task DeleteAsync(int id);
    }
}