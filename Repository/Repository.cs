using Emoloyee_Property_Mangment_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            var entities=_context.
                Set<T>().AsNoTracking()
                .Where(entity => entity.IsDeleted == false);
            return entities;

        }
        public T GetByID(int id)
        {
            T entity= _context.
                Set<T>().AsNoTracking().

                FirstOrDefault(entity => entity.Id == id && !entity.IsDeleted);
            return entity;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }
        public T Update(T entity)
        {
            try
            {

                var trackedEntity = _context.ChangeTracker.Entries<T>()
       .FirstOrDefault(e => e.Entity.Id == entity.Id);

                if (trackedEntity != null)
                {
                    trackedEntity.CurrentValues.SetValues(entity);
                }
                else
                {
                    _context.Set<T>().Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }
                return entity;
            }
            catch
            {
                throw new Exception("errorin editing ");
            }


        }
        public bool Delete(int id)
        {

            var deletedEntity = _context.Set<T>().FirstOrDefault(entity => entity.Id == id);
            deletedEntity.IsDeleted = true;
            return true;
        }
        public async Task SaveChanges()
        {
         await   _context.SaveChangesAsync();

        
        }
    }
}
