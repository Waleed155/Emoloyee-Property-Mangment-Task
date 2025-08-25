using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Attribute
{
    public class UniqueCode : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                string ?code = value as string;
                if (!string.IsNullOrEmpty(code))
                {
                    var _context = (DbContext)validationContext.GetService(typeof(DbContext))!;
                     
                    Employee employee = _context.Set<Employee>().FirstOrDefault(entity => entity.Code == code)!;
                    var employee1 = validationContext.ObjectInstance as EmployeeFormViewModel;
                    
                    if (employee==null||employee.Id == employee1.Id)
                    {
                        return ValidationResult.Success;

                    }
                    else
                    {
                        return new ValidationResult("This code Already Exist");
                    }
                }
                else
                    return new ValidationResult("you must enter value ");



            }
            catch 
            {

                throw new Exception("error in db");
            }
        }
    }
}
