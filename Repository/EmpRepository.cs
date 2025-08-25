 using Emoloyee_Property_Mangment_Task.Dto.EmployeeDto;
using Emoloyee_Property_Mangment_Task.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Repository
{
    public class EmpRepository:IEmpRepository
    {
        DbContext _context;
        public EmpRepository(DbContext context)
        {
            _context = context;
        }   
        public IQueryable<Employee> GetAll()
        {
            return _context.Set<Employee>().AsNoTracking().
                    Include(emp => emp.EmployeeProperties)!.
                    ThenInclude(empP => empP.Property).Where(emp => !emp.IsDeleted);
                 
                  
        }
        public Employee Get(int id) {
            var employee = _context.Set<Employee>().AsNoTracking().
                       Include(emp => emp.EmployeeProperties)!.
                       ThenInclude(empP => empP.Property).
                       FirstOrDefault(emp => emp.Id == id && !emp.IsDeleted);
            if (employee == null)
            {
                return new Employee();
            }
            else
                return employee;
        }
       
    }
}
