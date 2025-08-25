using Emoloyee_Property_Mangment_Task.Models;

namespace Emoloyee_Property_Mangment_Task.ViewModel
{
    public class PropertyAddViewModel
    {
        public int Id { get; set; }
        [Attribute.RequiredValidation]
        public string ?Value { get; set; }
        public string Name { get; set; }

        public PropertyType propertyType { get; set; }
        public bool IsRequired { get; set; } = true;

        public string? DropDownValues { get; set; }
    }
}
