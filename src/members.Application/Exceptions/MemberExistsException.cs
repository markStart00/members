namespace members.Application.Exceptions
{
    public class MemberExistsException : Exception
    {
        public MemberExistsException() : base() { }
        public MemberExistsException(string message) : base(message) { }
        public MemberExistsException(string message, Exception innerException) : base(message, innerException) { }

    }
}
