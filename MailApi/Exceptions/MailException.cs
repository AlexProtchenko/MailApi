namespace MailApi.Exceptions;

public abstract class MailException : Exception
{
    public MailException(string message): base(message)
    {
    }
    
    public class MailValidationException: MailException
    {
        public MailValidationException(string message) : base(message)
        {
        }
        
    }
}