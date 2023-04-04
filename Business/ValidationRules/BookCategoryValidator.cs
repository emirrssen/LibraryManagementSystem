using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BookCategoryValidator : AbstractValidator<BookCategory>
    {
        public BookCategoryValidator()
        {
            RuleFor(x => x.BookId).NotNull();
            RuleFor(x => x.BookId).NotEmpty();

            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
