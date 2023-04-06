using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> RegisterAsStudent(StudentForRegisterDto studentForRegister);
        IDataResult<User> RegisterAsPerson(PersonForRegisterDto personForRegister);
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
