using System.ComponentModel.DataAnnotations.Schema;

namespace Emoloyee_Property_Mangment_Task.Dto.EmployeePropertyDto
{
    
    public class EmployeePropertyDto
    { 
    public string? Value { get; set; }
    public int EmployeeId { get; set; }
    public int PropertyId { get; set; }
    
    }
}
