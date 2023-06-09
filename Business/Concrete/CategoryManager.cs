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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [SecuredOperation("employee")]
        [TransactionScopeAspect]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result, Messages.CategoriesListed);
        }

        [SecuredOperation("employee")]
        [SecuredOperation("user")]
        [CacheAspect]
        public IDataResult<Category> GetById(int categoryId)
        {
            var result = _categoryDal.Get(x => x.Id == categoryId);
            return new SuccessDataResult<Category>(result, Messages.CategoryListed);
        }
    }
}
