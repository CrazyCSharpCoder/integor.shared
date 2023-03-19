using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IntegorErrorsHandling.ExtensibleError
{
	using ErrorReading;

	public class ExtensibleErrorReader : IErrorReader<ExtensibleResponseError>
	{
		public ExtensibleResponseError ReadError(object errorObject)
		{
			List<ResponseErrorMixinAbstract> mixins = new List<ResponseErrorMixinAbstract>();

			foreach (PropertyInfo prop in errorObject.GetType().GetProperties())
				mixins.Add(PropertyToMixin(prop, errorObject));

			return new ExtensibleResponseError(mixins);
		}

		private ResponseErrorMixinAbstract PropertyToMixin(PropertyInfo prop, object errorObject)
		{
			Type mixinType = typeof(ResponseErrorMixin<>);
			Type propType = prop.PropertyType;

			mixinType = mixinType.MakeGenericType(propType);

			string key = prop.Name;
			object? value = prop.GetValue(errorObject);

			object mixinInstance = Activator.CreateInstance(mixinType, key, value)!;

			return (ResponseErrorMixinAbstract)mixinInstance;
		}
	}
}
