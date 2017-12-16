using System.Linq;
using BachelorManagement.BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BachelorManagement.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly BachelorManagementContext _context =
            new BachelorManagementContext(new DbContextOptions<BachelorManagementContext>());

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