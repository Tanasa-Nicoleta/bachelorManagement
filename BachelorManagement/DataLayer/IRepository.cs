using System.Linq;

namespace BachelorManagement.DataLayer
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAll();
        T GetSingle(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}