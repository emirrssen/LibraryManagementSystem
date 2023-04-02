using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookCategoryService
    {
        IResult Add(BookCategory bookCategory);
        IResult Delete(BookCategory bookCategory);
        IResult Update(BookCategory bookCategory);
        IDataResult<List<BookCategory>> GetAll();
        IDataResult<BookCategory> GetById(int bookCategoryId);
    }
}
