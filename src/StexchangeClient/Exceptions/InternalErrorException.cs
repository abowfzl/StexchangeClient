using System;

namespace StexchangeClient.Exceptions
{
    public class InternalErrorException : StexchangeException
    {
        public InternalErrorException(int id) : base($"id: {id} internal error")
        {

        }
    }
}
