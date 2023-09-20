using System;

namespace StexchangeClient.Exceptions
{
    public class ServiceTimoutException : StexchangeException
    {
        public ServiceTimoutException(int id) : base($"id: {id} service timeout")
        {

        }
    }
}
