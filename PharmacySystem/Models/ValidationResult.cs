using System.Collections.Generic;
using System.Linq;

namespace PharmacySystem.Models
{
    public class ValidationResult
    {
        public Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();

        public bool IsValid => !Errors.Any();

        public void AddError(string field, string message)
        {
            Errors[field] = message;
        }

        public string GetFirstError()
        {
            return Errors.Values.FirstOrDefault() ?? "Validation failed.";
        }
    }
}
