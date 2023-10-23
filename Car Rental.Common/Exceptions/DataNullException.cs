namespace Car_Rental.Common.Exceptions;

public class DataNullException : ArgumentNullException
{
    public DataNullException(string message) : base(message)
    {
        
    }
}
