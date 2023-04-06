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
    public class BookCategoryManager : IBookCategoryService
    {
        private IBookCategoryDal _bookCategoryDal;

        public BookCategoryManager(IBookCategoryDal bookCategoryDal)
        {
            _bookCategoryDal = bookCategoryDal;
        }

        [ValidationAspect(typeof(BookCategoryValidator))]
        [SecuredOperation("employee")]
        public IResult Add(BookCategory bookCategory)
        {
            _bookCategoryDal.Add(bookCategory);
            return new SuccessResult(Messages.BookCategoryAdded);
        }

        [ValidationAspect(typeof(BookCategoryValidator))]
        [SecuredOperation("employee")]
        public IResult Delete(BookCategory bookCategory)
        {
            _bookCategoryDal.Delete(bookCategory);
            return new SuccessResult(Messages.BookCategoryDeleted);
        }

        [ValidationAspect(typeof(BookCategoryValidator))]
        [SecuredOperation("employee")]
        public IResult Update(BookCategory bookCategory)
        {
            _bookCategoryDal.Update(bookCategory);
            return new SuccessResult(Messages.BookCategoryUpdated);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<List<BookCategory>> GetAll()
        {
            var result = _bookCategoryDal.GetAll();
            return new SuccessDataResult<List<BookCategory>>(result, Messages.BookCategoriesListed);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<BookCategory> GetById(int bookCategoryId)
        {
            var result = _bookCategoryDal.Get(x => x.Id == bookCategoryId);
            return new SuccessDataResult<BookCategory>(result, Messages.BookCategoryListed);
        }
    }
}
