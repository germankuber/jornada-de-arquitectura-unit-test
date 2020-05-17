namespace UnitTestExample.Core.Strategy
{
    public class ValidationResult
    {
        public bool Valid { get; set; }
        public string Error { get; set; }

        public ValidationResult()
        {
            Valid = true;
        }

        public ValidationResult(string error)
        {
            Valid = false;
            Error = error;
        }
    }
}