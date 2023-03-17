using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorGlobalConstants.DtoValidationMessages.Authorization
{
	public static class AuthorizationErrors
	{
		public const string IncorrectPasswordErrorMessage =
			"The \"{0}\" field can contain only the Latin alphabet characters and digits. " +
			"Additionally it must have at least one digit, one lowercase and one uppercase Latin characters";
	}
}
