using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(250);
            RuleFor(x => x.FirstName).MinimumLength(2);

            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).MaximumLength(250);
            RuleFor(x => x.LastName).MinimumLength(2);
        }
    }
}
