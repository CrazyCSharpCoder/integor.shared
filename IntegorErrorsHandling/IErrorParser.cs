using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling
{
    public interface IErrorParser<TError, TReadableObject> where TError : IResponseError
    {
        TError? ParseError(TReadableObject errorObject);
    }
}
