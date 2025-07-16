using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Exceptions
{
    internal class ValidationException: Exception
    {
        public ValidationException(): this("validation error occured")
        {
            
        }

        public ValidationException(String Message): base(Message) 
        {
            
        }

        public ValidationException(Exception ex): this(ex.Message) 
        {
            
        }
    }
}
