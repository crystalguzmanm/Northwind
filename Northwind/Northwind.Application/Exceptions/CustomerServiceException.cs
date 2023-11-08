using System;

namespace Northwind.Application.Exceptions
{
    public class CustomerServiceException : Exception
    {
        public CustomerServiceException(string message) :base(message) 
        {
        
        }
    }
}
