using System;

namespace StexchangeClient.Exceptions
{
    public class RepeatUpdateException : StexchangeException
    {
        public RepeatUpdateException(int id) : base($"id: {id} repeat update")
        {

        }
    }
}
