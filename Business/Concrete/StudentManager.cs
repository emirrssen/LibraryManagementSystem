using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac;
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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        [ValidationAspect(typeof(StudentValidator))]
        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IResult Add(Student student)
        {
            _studentDal.Add(student);
            return new SuccessResult(Messages.StudentAdded);
        }

        [ValidationAspect(typeof(StudentValidator))]
        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IResult Delete(Student student)
        {
            _studentDal.Delete(student);
            return new SuccessResult(Messages.StudentDeleted);
        }

        [ValidationAspect(typeof(StudentValidator))]
        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IResult Update(Student student)
        {
            _studentDal.Update(student);
            return new SuccessResult(Messages.StudentUpdated);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IDataResult<List<Student>> GetAll()
        {
            var result = _studentDal.GetAll();
            return new SuccessDataResult<List<Student>>(result, Messages.StudentsListed);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IDataResult<Student> GetById(int userId)
        {
            var result = _studentDal.Get(x => x.UserId == userId);
            return new SuccessDataResult<Student>(result, Messages.StudentListed);
        }
    }
}
