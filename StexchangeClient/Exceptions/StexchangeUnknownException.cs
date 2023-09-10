using System;

namespace StexchangeClient.Exceptions
{
    public class StexchangeUnknownException : StexchangeException
    {
        public StexchangeUnknownException(string message) : base($"unknown exception: {message}")
        {

        }
    }
}
