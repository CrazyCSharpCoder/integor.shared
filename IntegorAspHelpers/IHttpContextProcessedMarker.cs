﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorAspHelpers
{
	public interface IHttpContextProcessedMarker
	{
		void SetProcessed(bool processed);
		bool? GetProcessed();
		bool IsProcessed();
	}
}
