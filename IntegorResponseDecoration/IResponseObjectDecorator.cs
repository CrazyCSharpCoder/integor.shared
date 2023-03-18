using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration
{
    public interface IResponseObjectDecorator
    {
        ResponseBodyDecorationResult Decorate(object? bodyObject);
    }
}
