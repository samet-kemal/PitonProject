using PitonProject.Context;
using PitonProject.Models.Base;
using PitonProject.Services;
using System.Collections.Generic;
using System.Linq;

namespace PitonProject.Repository
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly PitonDbContext _context;

        public Repository(PitonDbContext context)
        {
            _context = context;
        }

        public bool Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<T> GetAll()
        {
            var list = _context.Set<T>().ToList();
            return list;
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
