using System;

namespace StexchangeClient.Exceptions
{
    public class InvalidArgumentException : StexchangeException
    {
        public InvalidArgumentException(int id) : base($"id: {id} invalid argument")
        {

        }
    }
}
