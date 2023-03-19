using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling.ErrorReading
{
	public interface IErrorReader<TError> where TError : IResponseError
	{
		TError ReadError(object errorObject);
	}
}
