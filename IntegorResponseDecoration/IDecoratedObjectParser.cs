using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration
{
	public interface IDecoratedObjectParser<TDecoratedRepresentation>
	{
		ResponseObjectDecorationResult ParseDecorated(TDecoratedRepresentation? decoratedObject);
	}
}
