using System;

namespace StexchangeClient.Exceptions
{
    public class EmptyResponseException : StexchangeException
    {
        public EmptyResponseException(int id) : base($"id: {id} neither error and result fields available")
        {

        }
    }
}
