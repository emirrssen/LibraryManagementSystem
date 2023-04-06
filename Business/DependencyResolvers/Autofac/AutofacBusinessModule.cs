using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().SingleInstance();
            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();

            builder.RegisterType<EfBookAuthorDal>().As<IBookAuthorDal>().SingleInstance();
            builder.RegisterType<BookAuthorManager>().As<IBookAuthorService>().SingleInstance();

            builder.RegisterType<EfBookCategoryDal>().As<IBookCategoryDal>().SingleInstance();
            builder.RegisterType<BookCategoryManager>().As<IBookCategoryService>().SingleInstance();

            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();

            builder.RegisterType<EfBorrowDal>().As<IBorrowDal>().SingleInstance();
            builder.RegisterType<BorrowManager>().As<IBorrowService>().SingleInstance();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();

            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();

            builder.RegisterType<EfPersonelDal>().As<IPersonelDal>().SingleInstance();
            builder.RegisterType<PersonelManager>().As<IPersonelService>().SingleInstance();

            builder.RegisterType<EfPersonDal>().As<IPersonDal>().SingleInstance();
            builder.RegisterType<PersonManager>().As<IPersonService>().SingleInstance();

            builder.RegisterType<EfStudentDal>().As<IStudentDal>().SingleInstance();
            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JWTHelper>().As<ITokenHelper>();

            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
