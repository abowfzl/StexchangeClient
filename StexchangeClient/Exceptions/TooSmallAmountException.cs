using System;

namespace StexchangeClient.Exceptions
{
    public class TooSmallAmountException : StexchangeException
    {
        public TooSmallAmountException(int id) : base($"id: {id} amount is too small")
        {

        }
    }
}
