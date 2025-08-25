using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Models
{
    public class Employee:BaseModel
    {
        public string Name { get; set; }
        [Attribute.UniqueCode]
        public string Code { get; set; }

        public HashSet<EmployeeProperty>? EmployeeProperties { get; set; }

    }
}
