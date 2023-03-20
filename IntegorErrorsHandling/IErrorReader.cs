using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling
{
    public interface IErrorReader<TError, TReadableObject> where TError : IResponseError
    {
        TError ReadError(TReadableObject errorObject);
    }
}
