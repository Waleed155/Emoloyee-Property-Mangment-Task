using Emoloyee_Property_Mangment_Task.Dto.EmployeeDto;
using Emoloyee_Property_Mangment_Task.Models;

namespace Emoloyee_Property_Mangment_Task.Services
{
    public interface IEmployeeService
    {
        public IQueryable<EmployeeDto> GetAll();
        public EmployeeAddDto GetFormAddEmployee();
        public EmployeeAddDto GetById(int id);
        public Task< bool> Add(EmployeeAddDto employeeAddDto);
        public  Task<bool> Edit(EmployeeAddDto employeeAddDto);
        public Task<bool> Delete(int id);
    }
}
