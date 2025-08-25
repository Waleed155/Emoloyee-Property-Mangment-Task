
using System.ComponentModel.DataAnnotations.Schema;

namespace Emoloyee_Property_Mangment_Task.Models
{
    public class EmployeeProperty:BaseModel
    {
        [Attribute.RequiredValidation]
        public string ? Value     { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Employee? Employee { get; set; }
        public Property? Property { get; set; }

    }
}
