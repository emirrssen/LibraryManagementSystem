using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
        IDataResult<List<Book>> GetAll();
        IDataResult<Book> GetById(int bookId);
    }
}
