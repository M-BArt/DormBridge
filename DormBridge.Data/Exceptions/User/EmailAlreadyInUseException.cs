﻿namespace DormBridge.Application.Exceptions.User
{
    public sealed class EmailAlreadyInUseException : Exception
    {
        public string Email { get; }
        public EmailAlreadyInUseException(string email) : base($"Email: {email} is already in use.")
        {
            Email = email;
        }
    }
}