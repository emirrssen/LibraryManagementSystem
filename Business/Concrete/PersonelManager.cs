﻿using Business.Abstract;
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
    public class PersonelManager : IPersonelService
    {
        private IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IResult Add(Personel personel)
        {
            _personelDal.Add(personel);
            return new SuccessResult(Messages.PersonelAdded);
        }

        public IResult Delete(Personel personel)
        {
            _personelDal.Delete(personel);
            return new SuccessResult(Messages.PersonelDeleted);
        }

        public IResult Update(Personel personel)
        {
            _personelDal.Update(personel);
            return new SuccessResult(Messages.PersonelUpdated);
        }

        public IDataResult<List<Personel>> GetAll()
        {
            var result = _personelDal.GetAll();
            return new SuccessDataResult<List<Personel>>(result, Messages.PersonelsListed);
        }

        public IDataResult<Personel> GetById(int userId)
        {
            var result = _personelDal.Get(x => x.UserId == userId);
            return new SuccessDataResult<Personel>(result, Messages.PersonelListed);
        }
    }
}
