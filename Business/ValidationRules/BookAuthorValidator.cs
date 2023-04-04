using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BookAuthorValidator : AbstractValidator<BookAuthor>
    {
        public BookAuthorValidator()
        {
            RuleFor(x => x.BookId).NotNull();
            RuleFor(x => x.BookId).NotEmpty();

            RuleFor(x => x.AuthorId).NotNull();
            RuleFor(x => x.AuthorId).NotEmpty();
        }
    }
}
