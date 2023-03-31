using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling
{
	public interface IHttpErrorsObjectParser<TReadableErrors>
	{
		IEnumerable<IResponseError>? GetErrors(TReadableErrors responseObject);
	}
}
