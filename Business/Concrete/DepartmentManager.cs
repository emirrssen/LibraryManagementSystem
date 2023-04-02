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
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.DepartmentAdded);
        }

        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.DepartmentDeleted);
        }

        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentUpdated);
        }

        public IDataResult<List<Department>> GetAll()
        {
            var result = _departmentDal.GetAll();
            return new SuccessDataResult<List<Department>>(result, Messages.DepartmentsListed);
        }

        public IDataResult<Department> GetById(int departmentId)
        {
            var result = _departmentDal.Get(x => x.Id == departmentId);
            return new SuccessDataResult<Department>(result, Messages.DepartmentListed);
        }
    }
}
