using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration.Parsing
{
    public interface IDecoratedObjectParser<TParseResult, TDecoratedRepresentation>
    {
        ResponseObjectParsingResult<TParseResult> ParseDecorated(TDecoratedRepresentation? decoratedObject);
    }
}
