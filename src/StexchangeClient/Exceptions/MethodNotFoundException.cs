using System;

namespace StexchangeClient.Exceptions
{
    public class MethodNotFoundException : StexchangeException
    {
        public MethodNotFoundException(int id) : base($"id: {id} method not found")
        {

        }
    }
}
