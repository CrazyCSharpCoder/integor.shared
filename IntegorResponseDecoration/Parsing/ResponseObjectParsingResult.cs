using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration.Parsing
{
	public class ResponseObjectParsingResult<TValue>
	{
		public bool Success { get; }
		public TValue? Value { get; }

		public ResponseObjectParsingResult(bool success)
		{
			Success = success;
		}

		/// <summary>
		/// Successful result with a new body for response
		/// </summary>
		public ResponseObjectParsingResult(TValue? newValue)
		{
			Success = true;
			Value = newValue;
		}
	}
}
