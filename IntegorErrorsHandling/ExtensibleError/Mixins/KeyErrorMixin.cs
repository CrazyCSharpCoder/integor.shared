using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling.ExtensibleError.Mixins
{
    using ExtensibleError;
    using static ExtensibleErrorMixinsDefaults;

    public class KeyErrorMixin : ResponseErrorMixin<string>
	{
		public KeyErrorMixin(string value) : base(KeyMixinKey, value)
		{
		}
	}
}
