using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookAuthorService
    {
        IResult Add(BookAuthor bookAuthor);
        IResult Delete(BookAuthor bookAuthor);
        IResult Update(BookAuthor bookAuthor);
        IDataResult<List<BookAuthor>> GetAll();
        IDataResult<BookAuthor> GetById(int bookAuthorId);
    }
}
