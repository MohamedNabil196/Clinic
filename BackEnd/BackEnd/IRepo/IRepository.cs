using System.Linq.Expressions;

namespace BackEnd.IRepo
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        //   IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T entity);
        void Save();
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        //Task<int> SaveAsync();
        Task<int> DeleteAsync(T entity);
        bool DeleteAsynctrue(T entity);

    }
}
