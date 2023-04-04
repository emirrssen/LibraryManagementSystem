using Core.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class NotValidValidatorException : ExceptionBase
    {
        public NotValidValidatorException(string message) : base(message, HttpStatusCode.BadRequest) { }
    }
}
