using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("manager")]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        [SecuredOperation("manager")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        [SecuredOperation("manager")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        [SecuredOperation("manager")]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            var result = _operationClaimDal.GetAll();
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.OperationClaimsListed);
        }

        [SecuredOperation("manager")]
        public IDataResult<OperationClaim> GetById(int operationClaimId)
        {
            var result = _operationClaimDal.Get(x => x.Id == operationClaimId);
            return new SuccessDataResult<OperationClaim>(result, Messages.OperationClaimListed);
        }
    }
}
