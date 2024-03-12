using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public sealed class IsEmailPasswordEqualAttribute: ValidationAttribute
    {
        public string PropertyName { get; }


        public IsEmailPasswordEqualAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            var valueToCheck = instance.GetType().GetProperty(PropertyName).GetValue(instance);
            if(value.ToString() != valueToCheck.ToString())
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("E-Mail and Password must not be identical!");
            }
        }


    }
}
