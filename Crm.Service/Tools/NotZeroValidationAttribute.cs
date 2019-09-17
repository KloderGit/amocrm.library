using System.ComponentModel.DataAnnotations;

namespace amocrm.library.Tools
{
    public class NotZeroValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((int)value == 0 || value == null)
            {
                this.ErrorMessage = this.ErrorMessage ?? $"Field can't be zero or null";
                return false;
            } 

            return true;
        }
    }
}
