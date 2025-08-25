using Emoloyee_Property_Mangment_Task.Models;

namespace Emoloyee_Property_Mangment_Task.Repository

{  public interface IEmpRepository
    {
        public IQueryable<Employee> GetAll();
        public Employee Get(int id);
        
    }
}
