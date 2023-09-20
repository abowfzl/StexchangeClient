using System;

namespace StexchangeClient.Exceptions
{
    public class OrderNotFoundException : StexchangeException
    {
        public OrderNotFoundException(int id) : base($"id: {id} order not found")
        {

        }
    }
}
