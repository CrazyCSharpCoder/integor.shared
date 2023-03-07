using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorErrorsHandling.ExtensibleError.Mixins
{
    using static ExtensibleErrorMixinsDefaults;

	using Primitives;

	public class MessagesErrorMixin : ResponseErrorMixin<IEnumerable<string>>
	{
		public MessagesErrorMixin(IEnumerable<string> messages) : base(MessagesMixinKey, messages)
		{
		}
	}
}
