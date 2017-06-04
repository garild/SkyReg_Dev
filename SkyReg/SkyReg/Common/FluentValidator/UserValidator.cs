using DataLayer;
using FluentValidation;

namespace SkyReg.Common.FluentValidator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Login).NotEmpty();
        }
    }
}
