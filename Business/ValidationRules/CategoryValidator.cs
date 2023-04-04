using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.Name).MaximumLength(250);
        }
    }
}
