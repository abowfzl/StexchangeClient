using System;

namespace StexchangeClient.Exceptions
{
    public class ServiceUnavailableException : StexchangeException
    {
        public ServiceUnavailableException(int id) : base($"id: {id} service unavailable")
        {

        }
    }
}
