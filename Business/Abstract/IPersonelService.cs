using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        IResult Add(Personel personel);
        IResult Delete(Personel personel);
        IResult Update(Personel personel);
        IDataResult<List<Personel>> GetAll();
        IDataResult<Personel> GetById(int userId);
    }
}
