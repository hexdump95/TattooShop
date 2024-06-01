namespace Tattoo.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string detail) : base(detail)
        {
            Detail = detail;
        }

        public string Detail { get; set; }
    }
}
