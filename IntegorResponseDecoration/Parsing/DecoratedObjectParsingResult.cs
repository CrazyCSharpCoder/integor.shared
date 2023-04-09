using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration.Parsing
{
	public class DecoratedObjectParsingResult<TValue>
	{
		public bool Success { get; }
		public TValue? Value { get; }

		public DecoratedObjectParsingResult(bool success)
		{
			Success = success;
		}

		/// <summary>
		/// Successful result with a new body for response
		/// </summary>
		public DecoratedObjectParsingResult(TValue? value)
		{
			Success = true;
			Value = value;
		}
	}
}
