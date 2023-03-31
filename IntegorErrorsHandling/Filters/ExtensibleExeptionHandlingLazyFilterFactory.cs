using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IntegorErrorsHandling.Filters
{
	public class ExtensibleExeptionHandlingLazyFilterFactory : Attribute, IFilterFactory
	{
		public bool IsReusable => false;

		private Type[] _converterTypes;

		public ExtensibleExeptionHandlingLazyFilterFactory(params Type[] exceptionConverterTypes)
		{
			_converterTypes = exceptionConverterTypes;
		}

		public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
		{
			IResponseErrorsObjectCompiler errorsCompiler = serviceProvider.GetRequiredService<IResponseErrorsObjectCompiler>();
			return new ExtensibleExeptionHandlingLazyFilter(serviceProvider, errorsCompiler, _converterTypes);
		}
	}
}
