﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace IntegorAspHelpers.Http.Filters
{
	public class SetProcessedFilter : IActionFilter
	{
		private IHttpContextProcessedMarker _processedMarker;

		public SetProcessedFilter(IHttpContextProcessedMarker processedMarker)
		{
			_processedMarker = processedMarker;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			_processedMarker.SetProcessed(true);
		}
	}
}
