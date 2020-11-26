using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Infrastructure.Abstractions
{
    public interface IRepository<T, TKey>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        T Insert(T item);
        void Update(T item);
        void Delete(T item);
        Task<IEnumerable<T>> GetAsync(ISpecification<T> specification);
        Task<T> GetSingleAsync(ISpecification<T> specification);
    }
}
