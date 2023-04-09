using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling
{
	public interface IResponseErrorsObjectCompiler
	{
		object CompileResponse(params IErrorConvertationResult[] errors);
		object CompileResponse(params IResponseError[] errors);
	}
}
