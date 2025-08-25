using Emoloyee_Property_Mangment_Task.Models;

namespace Emoloyee_Property_Mangment_Task.Dto.EmployeeDto
{
    public class EmployeeAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public HashSet<PropertyDto.PropertyAddDto>? Properties { get; set; }

    }
}
