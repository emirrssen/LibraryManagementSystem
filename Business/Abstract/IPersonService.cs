using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person);
        IResult Delete(Person person);
        IResult Update(Person person);
        IDataResult<List<Person>> GetAll();
        IDataResult<Person> GetById(int userId);
    }
}
