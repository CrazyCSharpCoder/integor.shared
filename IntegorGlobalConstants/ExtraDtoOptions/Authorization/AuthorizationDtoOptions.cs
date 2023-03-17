using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorGlobalConstants.ExtraDtoOptions.Authorization
{
	public static class AuthorizationDtoOptions
	{
		public const int MinPasswordLength = 8;
		public const string PasswordValidatonRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]+$";
	}
}
