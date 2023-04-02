using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBorrowService
    {
        IResult Add(Borrow borrow);
        IResult Delete(Borrow borrow);
        IResult Update(Borrow borrow);
        IDataResult<List<Borrow>> GetAll();
        IDataResult<Borrow> GetById(int borrowId);
    }
}
