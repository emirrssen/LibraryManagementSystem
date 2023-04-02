using Core.Entity.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<OperationClaim> GetById(int operationClaimId);
    }
}
