using Emoloyee_Property_Mangment_Task.Models;

namespace Emoloyee_Property_Mangment_Task.Repository
{
    public interface IEmployeePropertyRepository
    {
        public HashSet<EmployeeProperty> BulkInsert(HashSet<EmployeeProperty> employeeProperties);
        public EmployeeProperty Get(int empId, int propId);
        public IQueryable<EmployeeProperty> GetValuesByEmpID(int id);

        public Task SaveChanges();

    }
}
