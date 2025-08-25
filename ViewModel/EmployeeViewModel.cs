using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;

namespace Emoloyee_Property_Mangment_Task.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public HashSet<EmployeePropertyViewModel>? EmployeeProperties { get; set; }
    }
}
