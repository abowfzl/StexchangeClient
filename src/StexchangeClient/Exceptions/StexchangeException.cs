using System;

namespace StexchangeClient.Exceptions
{
    public class StexchangeException : Exception
    {
        public StexchangeException(string message) : base(message)
        {

        }
    }
}
