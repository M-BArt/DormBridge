namespace DormBridge.Application.Exceptions.User
{
    public sealed class EmailAlreadyInUseException : BusinessException
    {
        public string Email { get; }
        public EmailAlreadyInUseException(string email) : base($"Oops! '{email}' is already in use. Please try another.")
        {
            Email = email;
        }
    }
}