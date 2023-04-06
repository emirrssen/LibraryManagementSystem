using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(x => x.Email == email);
            return new SuccessDataResult<User>(result, Messages.UserListed);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        [SecuredOperation("manager")]
        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        [TransactionScopeAspect]
        public IResult UpdateProfile(UserForUpdateDto userForUpdate)
        {
            var userToUpdate = GetByMail(userForUpdate.Email).Data;
            var checkedPassword = HashingHelper.VerifyPasswordHash(userForUpdate.Password, userToUpdate.PasswordHash, userToUpdate.PasswordSalt);

            if (!checkedPassword)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userForUpdate.Password, out passwordHash, out passwordSalt);
                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;
                _userDal.Update(userToUpdate);

                return new SuccessResult(Messages.UserUpdatedSuccessfully);
            }

            return new ErrorResult(Messages.FieldsCannotBeSame);
        }
    }
}
