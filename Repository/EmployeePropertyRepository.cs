

using Emoloyee_Property_Mangment_Task.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Repository
{
    public class EmployeePropertyRepository:IEmployeePropertyRepository
    {
        DbContext _db;

        public EmployeePropertyRepository(DbContext db)
        {

            _db = db;
        }
        public HashSet<EmployeeProperty> BulkInsert(HashSet<EmployeeProperty> employeeProperties)
        {
            foreach (var employeeProperty in employeeProperties)
            {
                _db.Set<EmployeeProperty>().Add(employeeProperty);
            }
            return employeeProperties;

        }
        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
        public EmployeeProperty Get(int empId,int propId )
        {
            return _db.Set<EmployeeProperty>().
                    FirstOrDefault(empp => empp.PropertyId == propId && empp.EmployeeId == empId && !empp.IsDeleted);

        
        }
        public IQueryable<EmployeeProperty> GetValuesByEmpID(int id)
        {
            return _db.Set<EmployeeProperty>().Where(empP => empP.EmployeeId == id);
        }
    }
}
