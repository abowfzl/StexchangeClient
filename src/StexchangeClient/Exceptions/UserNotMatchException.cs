using System;

namespace StexchangeClient.Exceptions
{
    public class UserNotMatchException : StexchangeException
    {
        public UserNotMatchException(int id) : base($"id: {id} user not match")
        {

        }
    }
}
