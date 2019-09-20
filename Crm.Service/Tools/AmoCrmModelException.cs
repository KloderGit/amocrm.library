using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace amocrm.library.Tools
{
    public class AmoCrmModelException : Exception
    {
        IEnumerable<ValidationResult> Errors { get; set; } = new List<ValidationResult>();

        public AmoCrmModelException(IEnumerable<ValidationResult> errors)
            : base(String.Join(" | ", errors.Select(x => x.ErrorMessage)))
        {
            Errors = errors;
        }
    }
}
