using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
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
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        [ValidationAspect(typeof(DepartmentValidator))]
        [SecuredOperation("director")]
        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.DepartmentAdded);
        }

        [ValidationAspect(typeof(DepartmentValidator))]
        [SecuredOperation("manager")]
        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.DepartmentDeleted);
        }

        [ValidationAspect(typeof(DepartmentValidator))]
        [SecuredOperation("manager")]
        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentUpdated);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [CacheAspect]
        public IDataResult<List<Department>> GetAll()
        {
            var result = _departmentDal.GetAll();
            return new SuccessDataResult<List<Department>>(result, Messages.DepartmentsListed);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [CacheAspect]
        public IDataResult<Department> GetById(int departmentId)
        {
            var result = _departmentDal.Get(x => x.Id == departmentId);
            return new SuccessDataResult<Department>(result, Messages.DepartmentListed);
        }
    }
}
