using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IntegorResponseDecoration
{
    public class ResponseObjectDecorationFilterFactory : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        private IEnumerable<Type> _decoratorTypes;

        public ResponseObjectDecorationFilterFactory(params Type[] decoratorTypes)
        {
            _decoratorTypes = decoratorTypes;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            IEnumerable<IResponseObjectOneSideDecorator> decorators = _decoratorTypes.Select(
                decType => (IResponseObjectOneSideDecorator)serviceProvider.GetRequiredService(decType));

            Type filterType = typeof(ResponseObjectDecorationFilter);
            return (Activator.CreateInstance(filterType, decorators) as IFilterMetadata)!;
        }

        private class ResponseObjectDecorationFilter : IActionFilter
        {
            private IEnumerable<IResponseObjectOneSideDecorator> _decorators;

            public ResponseObjectDecorationFilter(IEnumerable<IResponseObjectOneSideDecorator> decorators)
            {
                _decorators = decorators;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                if (context.Result == null)
                    return;

                ObjectResult? result = context.Result as ObjectResult;

                if (result == null)
                    return;

                result.Value = Decorate(_decorators, result.Value);
            }

            private object? Decorate(IEnumerable<IResponseObjectOneSideDecorator> decorators, object? body)
            {
                foreach (IResponseObjectOneSideDecorator decorator in decorators)
                {
                    ResponseObjectDecorationResult decorationResult = decorator.Decorate(body);

                    if (decorationResult.Success)
                        return decorationResult.NewValue;
                }

                return body;
            }
        }
    }
}
