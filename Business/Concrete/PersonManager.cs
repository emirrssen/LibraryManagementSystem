using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        [ValidationAspect(typeof(PersonValidator))]
        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Add(Person person)
        {
            _personDal.Add(person);
            return new SuccessResult(Messages.PersonAdded);
        }

        [ValidationAspect(typeof(PersonValidator))]
        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Delete(Person person)
        {
            _personDal.Delete(person);
            return new SuccessResult(Messages.PersonDeleted);
        }

        [ValidationAspect(typeof(PersonValidator))]
        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Update(Person person)
        {
            _personDal.Update(person);
            return new SuccessResult(Messages.PersonUpdated);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [CacheAspect]
        public IDataResult<List<Person>> GetAll()
        {
            var result = _personDal.GetAll();
            return new SuccessDataResult<List<Person>>(result, Messages.PersonsListed);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [CacheAspect]
        public IDataResult<Person> GetById(int userId)
        {
            var result = _personDal.Get(x => x.UserId == userId);
            return new SuccessDataResult<Person>(result, Messages.PersonListed);
        }
    }
}
