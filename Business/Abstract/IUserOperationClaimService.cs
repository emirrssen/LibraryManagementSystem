﻿using Core.Entity.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult AddClaim(UserOperationClaim userOperationClaim);
        IResult AddDefaultClaim(User user);
    }
}
