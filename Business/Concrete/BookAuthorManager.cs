using Business.Abstract;
using Business.Constants;
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

        public IResult Add(BookAuthor bookAuthor)
        {
            _bookAuthorDal.Add(bookAuthor);
            return new SuccessResult(Messages.BookAuthorAdded);
        }

        public IResult Delete(BookAuthor bookAuthor)
        {
            _bookAuthorDal.Delete(bookAuthor);
            return new SuccessResult(Messages.BookAuthorDeleted);
        }

        public IResult Update(BookAuthor bookAuthor)
        {
            _bookAuthorDal.Update(bookAuthor);
            return new SuccessResult(Messages.BookAuthorUpdated);
        }

        public IDataResult<List<BookAuthor>> GetAll()
        {
            var result = _bookAuthorDal.GetAll();
            return new SuccessDataResult<List<BookAuthor>>(result, Messages.BookAuthorsListed);
        }

        public IDataResult<BookAuthor> GetById(int bookAuthorId)
        {
            var result = _bookAuthorDal.Get(x => x.Id == bookAuthorId);
            return new SuccessDataResult<BookAuthor>(result, Messages.BookAuthorListed);
        }
    }
}
