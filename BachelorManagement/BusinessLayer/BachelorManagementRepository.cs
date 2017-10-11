using System.Linq;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class BachelorManagementRepository<T>: IBachelorManagementRepository<T> where T : class, IEntityBase, new()
    {
        private readonly BachelorManagementContext _context = new BachelorManagementContext(options: new DbContextOptions<BachelorManagementContext>());

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
