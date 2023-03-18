﻿using System.ComponentModel.DataAnnotations;

using static IntegorGlobalConstants.ModelOptions.Authorization.UserAccountOptions;
using static IntegorGlobalConstants.ExtraDtoOptions.Authorization.AuthorizationDtoOptions;

using static IntegorGlobalConstants.DtoValidationMessages.DataAnnotationsErrors;
using static IntegorGlobalConstants.DtoValidationMessages.Authorization.AuthorizationErrors;

namespace IntegorPublicDto.Authorization.Users.Input
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [EmailAddress(ErrorMessage = EmailAddressErrorMessage)]
        [MaxLength(EMailLength, ErrorMessage = MaxStringLengthErrorMessage)]
        public string EMail { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PasswordHashLength, MinimumLength = MinPasswordLength, ErrorMessage = StringLengthErrorMessage)]
        [RegularExpression(PasswordValidatonRegex, ErrorMessage = IncorrectPasswordErrorMessage)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Compare(nameof(Password), ErrorMessage = CompareErrorMessage)]
        public string PasswordRepeat { get; set; } = null!;
    }
}
