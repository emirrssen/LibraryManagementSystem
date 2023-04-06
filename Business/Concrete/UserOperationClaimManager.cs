using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        [SecuredOperation("manager")]
        [TransactionScopeAspect]
        public IResult AddClaim(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.ClaimAdded);
        }

        [SecuredOperation("manager")]
        [TransactionScopeAspect]
        public IResult AddDefaultClaim(User user)
        {
            var recordToAdd = new UserOperationClaim { UserId = user.Id, OperationClaimId = 1 };
            _userOperationClaimDal.Add(recordToAdd);
            return new SuccessResult();
        }
    }
}
