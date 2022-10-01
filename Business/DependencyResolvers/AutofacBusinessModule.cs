using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Security.Jwt;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<DrinkManager>().As<IDrinkService>().SingleInstance();
            builder.RegisterType<DrinkDal>().As<IDrinkDal>().SingleInstance();

            builder.RegisterType<FoodManager>().As<IFoodService>().SingleInstance();
            builder.RegisterType<FoodDal>().As<IFoodDal>().SingleInstance();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<OrderDetailDal>().As<IOrderDetailDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<OrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<SweetManager>().As<ISweetService>().SingleInstance();
            builder.RegisterType<SweetDal>().As<ISweetDal>().SingleInstance();

            builder.RegisterType<MenuManager>().As<IMenuService>().SingleInstance();
            builder.RegisterType<MenuDal>().As<IMenuDal>().SingleInstance();///     private IUserService _userService;        private ITokenHelper _tokenHelper;

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
