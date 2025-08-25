using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Attribute
{
    public class RequiredValidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                string ?Value = value as string;
                var _context = (DbContext)validationContext.GetService(typeof(DbContext))!;

                var entity = validationContext.ObjectInstance as PropertyAddViewModel;

                if (string.IsNullOrEmpty(Value) && entity.IsRequired == true)
                {

                    return new ValidationResult("you must enter value ");



                }
                else
                    return ValidationResult.Success;



            }
            catch 
            {

                throw new Exception("error in db");
            }
        }
    }
}
