using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.DepartmentId).NotNull();
            RuleFor(x => x.DepartmentId).NotEmpty();

            RuleFor(x => x.Salary).NotNull();
            RuleFor(x => x.Salary).NotEmpty();
            RuleFor(x => x.Salary).GreaterThan(0);
        }
    }
}
