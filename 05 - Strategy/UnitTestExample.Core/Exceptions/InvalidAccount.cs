using System;
using System.Collections.Generic;

namespace UnitTestExample.Core.Exceptions
{
    public class InvalidAccountException : Exception
    {

        public InvalidAccountException(string error):base(error)
        {
        }
    }
}