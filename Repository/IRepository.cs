using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Repository
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public T GetByID(int id);
        public T Add(T entity);
        public T Update(T entity);
        public bool Delete(int id);
        public  Task SaveChanges();
    }
}
