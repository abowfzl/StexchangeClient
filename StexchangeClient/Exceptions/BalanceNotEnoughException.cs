using System;

namespace StexchangeClient.Exceptions
{
    public class BalanceNotEnoughException : StexchangeException
    {
        public BalanceNotEnoughException(int id) : base($"id: {id} balance not enough")
        {

        }
    }
}
