using System.ComponentModel.DataAnnotations;

namespace MVCCorePrj.Models
{
    public class SalaryValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int salary = (int)value;

            if (salary < 5000)
                return false;
            else
                return true;
        }
    }
}
