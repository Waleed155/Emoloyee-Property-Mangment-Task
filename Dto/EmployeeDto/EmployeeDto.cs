using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;


using Emoloyee_Property_Mangment_Task.Dto.EmployeePropertyDto;
namespace Emoloyee_Property_Mangment_Task.Dto.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
       public HashSet<EmployeePropertyDto.EmployeePropertyDto>? EmployeeProperties { get; set; }
       



    }
}
