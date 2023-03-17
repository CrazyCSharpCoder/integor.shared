using System.ComponentModel.DataAnnotations;

using static IntegorGlobalConstants.ModelOptions.Authorization.UserAccountOptions;
using static IntegorGlobalConstants.ExtraDtoOptions.Authorization.AuthorizationDtoOptions;

using static IntegorGlobalConstants.DtoValidationMessages.DataAnnotationsErrors;
using static IntegorGlobalConstants.DtoValidationMessages.Authorization.AuthorizationErrors;

namespace IntegorPublicDto.Authorization.Users.Input
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [EmailAddress(ErrorMessage = EmailAddressErrorMessage)]
        [MaxLength(EMailLength, ErrorMessage = MaxStringLengthErrorMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(PasswordValidatonRegex, ErrorMessage = IncorrectPasswordErrorMessage)]
        public string Password { get; set; } = null!;
    }
}
