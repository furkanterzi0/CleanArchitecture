using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Application.Exceptions
{
    public class ValidationException: Exception
    {
        public ValidationException() : this("validation error occured")
        {
            
        }

        public ValidationException(string message): base(message)
        {
            
        }

        public ValidationException(Exception ex): this(ex.Message) 
        {
            
        }
    }
    
}
