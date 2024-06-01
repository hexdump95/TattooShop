namespace Tattoo.Exceptions
{
    public class InvalidUserException : BaseException
    {
        public InvalidUserException() : base(@"Wrong username")
        {
        }
    }
}
