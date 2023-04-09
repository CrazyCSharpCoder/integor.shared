using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration.Parsing
{
	public abstract class DecoratedObjectParserBase<TParseResult>
	{
		protected DecoratedObjectParsingResult<TParseResult> Result(bool success)
			=> new DecoratedObjectParsingResult<TParseResult>(success);

		protected DecoratedObjectParsingResult<TParseResult> Result(TParseResult resultValue)
			=> new DecoratedObjectParsingResult<TParseResult>(resultValue);
	}
}
