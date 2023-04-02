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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public IResult Add(Student student)
        {
            _studentDal.Add(student);
            return new SuccessResult(Messages.StudentAdded);
        }

        public IResult Delete(Student student)
        {
            _studentDal.Delete(student);
            return new SuccessResult(Messages.StudentDeleted);
        }

        public IResult Update(Student student)
        {
            _studentDal.Update(student);
            return new SuccessResult(Messages.StudentUpdated);
        }

        public IDataResult<List<Student>> GetAll()
        {
            var result = _studentDal.GetAll();
            return new SuccessDataResult<List<Student>>(result, Messages.StudentsListed);
        }

        public IDataResult<Student> GetById(int userId)
        {
            var result = _studentDal.Get(x => x.UserId == userId);
            return new SuccessDataResult<Student>(result, Messages.StudentListed);
        }
    }
}
