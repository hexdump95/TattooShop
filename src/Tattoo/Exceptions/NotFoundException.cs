namespace Tattoo.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) doesn't exists.")
        {
        }
    }
}
