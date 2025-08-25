using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Emoloyee_Property_Mangment_Task.Attribute
{
    public class DropDownValues:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                var propertyViewModel = validationContext.ObjectInstance as PropertyViewModel;

                string? dropValue = value as  string;

                if (!string.IsNullOrEmpty(dropValue) && propertyViewModel.propertyType == PropertyType.DropDown)
                {
                    List<string> values = dropValue!.Split("-").ToList();
                    if ( values.Count > 1)
                    {
                        return ValidationResult.Success;

                    }
                    else
                    {
                        return new ValidationResult("You must enter the values of dropdown seperated by -");
                    }
                }
                else if(string.IsNullOrEmpty(dropValue) && propertyViewModel.propertyType != PropertyType.DropDown)
                {
                    return ValidationResult.Success;
                }
                else if (!string.IsNullOrEmpty(dropValue) && propertyViewModel.propertyType != PropertyType.DropDown)
                {
                    return new ValidationResult("You can not enter values when property type not equal DropDown" +
                        " ");
                }
                else
                {
                    return new ValidationResult("You must enter the values of dropdown seperated by -");

                }

            }
            catch 
            {

                return new ValidationResult("You must enter the values of dropdown seperated by -");
            }
        }
    }
}

