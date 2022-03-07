namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models
{
    public class ValidationResult
    {
        public string ErrorMessage { get; }
        public bool IsValid { get; }

        private ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult CreateInvalid(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }

        public static ValidationResult CreateValid()
        {
            return new ValidationResult(true, string.Empty);
        }
    }
}