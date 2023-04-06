using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IStudentService _studentService;
        private IPersonService _personService;
        private IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,
            IStudentService studentService, IPersonService personService,
            IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _studentService = studentService;
            _personService = personService;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<User> RegisterAsPerson(PersonForRegisterDto personForRegister)
        {
            var registerToolResult = RegisterTool(personForRegister);
            User registeredPerson = _userService.GetByMail(personForRegister.Email).Data;
            SetDefaultClaimTool(registeredPerson.Email);

            Person person = new Person
            {
                UserId = registeredPerson.Id
            };
            var result = _personService.Add(person);

            return new SuccessDataResult<User>(registerToolResult.Data, result.Message);
        }

        public IDataResult<User> RegisterAsStudent(StudentForRegisterDto studentForRegister)
        {
            var registerToolResult = RegisterTool(studentForRegister);
            User registeredStudent = _userService.GetByMail(studentForRegister.Email).Data;
            SetDefaultClaimTool(registeredStudent.Email);

            Student student = new Student
            {
                UserId = registeredStudent.Id,
                SchoolName = studentForRegister.SchoolName
            };
            var result = _studentService.Add(student);

            return new SuccessDataResult<User>(registerToolResult.Data, result.Message);
        }

        public IDataResult<User> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userService.GetByMail(userForLogin.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        private IDataResult<User> RegisterTool(UserForRegisterDto userForRegister)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                DateOfBirth = userForRegister.DateOfBirth,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        private void SetDefaultClaimTool(string userMail)
        {
            var user = _userService.GetByMail(userMail).Data;
            _userOperationClaimService.AddDefaultClaim(user);
        }
    }
}
