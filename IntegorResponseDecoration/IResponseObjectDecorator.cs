using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration
{
    public interface IResponseObjectDecorator
	{
		ResponseObjectDecorationResult Decorate(object? responseObject);
	}
}
