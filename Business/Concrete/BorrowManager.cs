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
    public class BorrowManager : IBorrowService
    {
        private IBorrowDal _borrowDal;

        public BorrowManager(IBorrowDal borrowDal)
        {
            _borrowDal = borrowDal;
        }

        [ValidationAspect(typeof(BorrowValidator))]
        [SecuredOperation("employee")]
        public IResult Add(Borrow borrow)
        {
            _borrowDal.Add(borrow);
            return new SuccessResult(Messages.BorrowAdded);
        }

        [ValidationAspect(typeof(BorrowValidator))]
        [SecuredOperation("employee")]
        public IResult Delete(Borrow borrow)
        {
            _borrowDal.Delete(borrow);
            return new SuccessResult(Messages.BorrowDeleted);
        }

        [ValidationAspect(typeof(BorrowValidator))]
        [SecuredOperation("employee")]
        public IResult Update(Borrow borrow)
        {
            _borrowDal.Update(borrow);
            return new SuccessResult(Messages.BorrowUpdated);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<List<Borrow>> GetAll()
        {
            var result = _borrowDal.GetAll();
            return new SuccessDataResult<List<Borrow>>(result, Messages.BorrowsListed);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        public IDataResult<Borrow> GetById(int borrowId)
        {
            var result = _borrowDal.Get(x => x.Id == borrowId);
            return new SuccessDataResult<Borrow>(result, Messages.BorrowListed);
        }
    }
}
