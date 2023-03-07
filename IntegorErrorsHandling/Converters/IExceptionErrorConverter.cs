using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling.Converters
{
    public interface IExceptionErrorConverter<TException> : IErrorConverter<TException>
        where TException : Exception
    {
    }
}
