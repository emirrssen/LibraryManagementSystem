using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.Name).MaximumLength(250);

            RuleFor(x => x.ISBN).NotEmpty();
            RuleFor(x => x.ISBN).NotNull();
            RuleFor(x => x.ISBN).MinimumLength(10);
            RuleFor(x => x.ISBN).MaximumLength(13);

            RuleFor(x => x.PageNumber).NotEmpty();
            RuleFor(x => x.PageNumber).NotNull();
            RuleFor(x => x.PageNumber).GreaterThan(0);
        }
    }
}
