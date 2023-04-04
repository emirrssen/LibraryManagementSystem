using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.SchoolName).NotNull();
            RuleFor(x => x.SchoolName).NotEmpty();
            RuleFor(x => x.SchoolName).MinimumLength(2);
            RuleFor(x => x.SchoolName).MaximumLength(250);
        }
    }
}
