using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BorrowValidator : AbstractValidator<Borrow>
    {
        public BorrowValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.BookId).NotNull();
            RuleFor(x => x.BookId).NotEmpty();

            RuleFor(x => x.BorrowDate).NotEmpty();
            RuleFor(x => x.BorrowDate).NotNull();
            RuleFor(x => x.BorrowDate).Must(DateMustBeToday);
        }

        private bool DateMustBeToday(DateTime arg)
        {

            if (arg.Day == DateTime.Now.Day 
                && arg.Month == DateTime.Now.Month 
                && arg.Year == DateTime.Now.Year)
            {
                return true;
            }
            return false;
        }
    }
}
