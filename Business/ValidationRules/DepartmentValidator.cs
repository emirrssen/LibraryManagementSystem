using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.Name).MaximumLength(250);
        }
    }
}
