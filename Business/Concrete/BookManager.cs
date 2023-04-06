using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [ValidationAspect(typeof(BookValidator))]
        [SecuredOperation("employee")]
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        [ValidationAspect(typeof(BookValidator))]
        [SecuredOperation("employee")]
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }

        [ValidationAspect(typeof(BookValidator))]
        [SecuredOperation("employee")]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<List<Book>> GetAll()
        {
            var result = _bookDal.GetAll();
            return new SuccessDataResult<List<Book>>(result, Messages.BooksListed);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<Book> GetById(int bookId)
        {
            var result = _bookDal.Get(x => x.Id == bookId);
            return new SuccessDataResult<Book>(result, Messages.BookListed);
        }
    }
}
