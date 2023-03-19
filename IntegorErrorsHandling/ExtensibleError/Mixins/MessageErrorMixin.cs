using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling.ExtensibleError.Mixins
{
    using ExtensibleError;
    using static ExtensibleErrorMixinsDefaults;

    public class MessageErrorMixin : ResponseErrorMixin<string>
	{
		public MessageErrorMixin(string message) : base(MessageMixinKey, message)
		{
		}
	}
}
