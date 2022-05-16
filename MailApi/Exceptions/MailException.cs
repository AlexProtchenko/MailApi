namespace MailApi.Exceptions;

public abstract class MailException : Exception
{
    private MailException(string message): base(message)
    {
    }
    
    public class MailValidationException: MailException
    {
        public MailValidationException(string message = "Wrong json request") : base(message)
        {
        }
    }
    
    public class MailUnauthorizedException: MailException
    {
        public MailUnauthorizedException(string message = "Incorrect token") : base(message)
        {
        }
    }
}