namespace Tattoo.Exceptions
{
    public class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException() : base("Wrong password")
        {
        }
    }
}
