using System;

namespace Utility.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {

        }
    }


    public class AuthorizationException : AppException
    {
        public AuthorizationException(string message) : base(message)
        {

        }
    }
}
