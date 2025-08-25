using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;

namespace Emoloyee_Property_Mangment_Task.ViewModel
{
    public class EmployeeFormViewModel
    {
       public int Id { get; set; }
       public string Name { get; set; }
        [Attribute.UniqueCode]
        public string Code { get; set; }
       public List <PropertyAddViewModel> ?PropertiesViewModel { get; set; }
    }
}
