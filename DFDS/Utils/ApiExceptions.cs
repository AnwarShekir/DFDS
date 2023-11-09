namespace DFDS.Utils
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException()
        {

        }
    }

    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException()
        {

        }
    }
}
