using System.Collections.Generic;

namespace PitonProject.Services
{
    public interface IRepository<T> where T: class 
    {
        T GetById(int id);
        List<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
