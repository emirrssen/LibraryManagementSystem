﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        [ValidationAspect(typeof(AuthorValidator))]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Add(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult(Messages.AuthorAdded);
        }

        [ValidationAspect(typeof(AuthorValidator))]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Delete(Author author)
        {
            _authorDal.Delete(author);
            return new SuccessResult(Messages.AuthorDeleted);
        }

        [ValidationAspect(typeof(AuthorValidator))]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Update(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult(Messages.AuthorUpdated);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        [CacheAspect]
        public IDataResult<List<Author>> GetAll()
        {
            var result = _authorDal.GetAll();
            return new SuccessDataResult<List<Author>>(result, Messages.AuthorsListed);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        [CacheAspect]
        public IDataResult<Author> GetById(int authorId)
        {
            var result = _authorDal.Get(x => x.Id == authorId);
            return new SuccessDataResult<Author>(result, Messages.AuthorListed);
        }
    }
}
