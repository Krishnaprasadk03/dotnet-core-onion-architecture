namespace Domain.Exceptions
{
    public class InActiveCleintException : Exception
    {
        public InActiveCleintException() : base("Client inactive or invalid")
        {

        }
    }
}