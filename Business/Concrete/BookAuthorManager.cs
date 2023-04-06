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
    public class BookAuthorManager : IBookAuthorService
    {
        private IBookAuthorDal _bookAuthorDal;

        public BookAuthorManager(IBookAuthorDal bookAuthorDal)
        {
            _bookAuthorDal = bookAuthorDal;
        }

        [ValidationAspect(typeof(BookAuthorValidator))]
        [SecuredOperation("employee")]
        public IResult Add(BookAuthor bookAuthor)
        {
            _bookAuthorDal.Add(bookAuthor);
            return new SuccessResult(Messages.BookAuthorAdded);
        }

        [ValidationAspect(typeof(BookAuthorValidator))]
        [SecuredOperation("employee")]
        public IResult Delete(BookAuthor bookAuthor)
        {
            _bookAuthorDal.Delete(bookAuthor);
            return new SuccessResult(Messages.BookAuthorDeleted);
        }

        [ValidationAspect(typeof(BookAuthorValidator))]
        [SecuredOperation("employee")]
        public IResult Update(BookAuthor bookAuthor)
        {
            _bookAuthorDal.Update(bookAuthor);
            return new SuccessResult(Messages.BookAuthorUpdated);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<List<BookAuthor>> GetAll()
        {
            var result = _bookAuthorDal.GetAll();
            return new SuccessDataResult<List<BookAuthor>>(result, Messages.BookAuthorsListed);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<BookAuthor> GetById(int bookAuthorId)
        {
            var result = _bookAuthorDal.Get(x => x.Id == bookAuthorId);
            return new SuccessDataResult<BookAuthor>(result, Messages.BookAuthorListed);
        }
    }
}
