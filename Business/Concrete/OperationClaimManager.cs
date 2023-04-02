using Business.Abstract;
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

        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            var result = _operationClaimDal.GetAll();
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.OperationClaimsListed);
        }

        public IDataResult<OperationClaim> GetById(int operationClaimId)
        {
            var result = _operationClaimDal.Get(x => x.Id == operationClaimId);
            return new SuccessDataResult<OperationClaim>(result, Messages.OperationClaimListed);
        }
    }
}
