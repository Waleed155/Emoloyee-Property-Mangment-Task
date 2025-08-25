using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Attribute
{
    public class UniqueProperty : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
         {
            try
            {
                string ?name = value as string;
                if (!string.IsNullOrEmpty(name))
                {
                    var _context = (DbContext)validationContext.GetService(typeof(DbContext))!;

                    Property property = _context.Set<Property>().FirstOrDefault(entity => entity.Name == name)!;
                    var property1 = validationContext.ObjectInstance as PropertyViewModel;
                    if (property == null)
                    {
                        return ValidationResult.Success;
                    }
                    else if (property.Id == property1.Id)
                    {
                        return ValidationResult.Success;

                    }
                    else
                    {
                        return new ValidationResult("This Property Already Exist");
                    }
                }
                else
                    return new ValidationResult("you must enter value ");



            }
            catch {

                return new ValidationResult("you must enter value ");
            }
        }   }
}
