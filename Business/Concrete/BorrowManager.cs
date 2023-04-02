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
    public class BorrowManager : IBorrowService
    {
        private IBorrowDal _borrowDal;

        public BorrowManager(IBorrowDal borrowDal)
        {
            _borrowDal = borrowDal;
        }
        public IResult Add(Borrow borrow)
        {
            _borrowDal.Add(borrow);
            return new SuccessResult(Messages.BorrowAdded);
        }

        public IResult Delete(Borrow borrow)
        {
            _borrowDal.Delete(borrow);
            return new SuccessResult(Messages.BorrowDeleted);
        }

        public IResult Update(Borrow borrow)
        {
            _borrowDal.Update(borrow);
            return new SuccessResult(Messages.BorrowUpdated);
        }

        public IDataResult<List<Borrow>> GetAll()
        {
            var result = _borrowDal.GetAll();
            return new SuccessDataResult<List<Borrow>>(result, Messages.BorrowsListed);
        }

        public IDataResult<Borrow> GetById(int borrowId)
        {
            var result = _borrowDal.Get(x => x.Id == borrowId);
            return new SuccessDataResult<Borrow>(result, Messages.BorrowListed);
        }
    }
}
