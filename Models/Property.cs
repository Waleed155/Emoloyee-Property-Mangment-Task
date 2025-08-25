using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Models
{
    public class Property:BaseModel
    {
        [Attribute.UniqueProperty]
        public string Name { get; set; }
     
        public PropertyType propertyType   { get; set; }
        public bool IsRequired { get; set; }

        [Attribute.DropDownValues]
        public string? DropDownValues { get; set; }
        public HashSet<EmployeeProperty>? EmployeeProperties { get; set; }


    }
}
