using Emoloyee_Property_Mangment_Task.Models;
using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Dto.PropertyDto
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PropertyType propertyType { get; set; }
        public bool IsRequired { get; set; } = true;
        public   string? DropDownValues { get; set; }
    }
}
