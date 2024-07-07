namespace Todo.Backend.TreatmentException;

public class TreatedException : Exception
{
    public int ErrorCode { get; set; }
    public string ErrorDetails { get; set; }

    public TreatedException(string message, int errorCode, string errorDetails) : base(message) 
    {
        ErrorCode = errorCode;
        ErrorDetails = errorDetails;
    }
}
