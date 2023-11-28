using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
  
        public class UnableToRegisterCustomerException : Exception
        {
            string message;
            public UnableToRegisterCustomerException()
            {
                message = "The action you have specified is not valid";
            }
            public override string Message => message;

        }

    
}
