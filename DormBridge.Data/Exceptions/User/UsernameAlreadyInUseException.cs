namespace DormBridge.Application.Exceptions.User
{
    public sealed class UsernameAlreadyInUseException : BusinessException
    {
        public string Username { get; }
        public UsernameAlreadyInUseException(string username) : base($"Username: {username} is already in use.")
        {
            Username = username;
        }
    }
}