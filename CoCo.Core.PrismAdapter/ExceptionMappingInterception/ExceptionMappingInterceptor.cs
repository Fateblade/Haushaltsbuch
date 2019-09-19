using Castle.DynamicProxy;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Ninject.Infrastructure.Language;
using System;
using System.Linq;
using System.Reflection;

namespace Fateblade.Haushaltsbuch.CrossCutting.CoCo.Core.PrismAdapter.ExceptionMappingInterception
{
    public class ExceptionMappingInterceptor : IInterceptor
    {
// Todo: könnte man komplett aus Tielke übernehmen, verwendet lediglich Language features von Ninject nicht den eigentlichen Adapter
        public void Intercept(IInvocation invocation)
        {
            var interceptedType = invocation.TargetType;
            var mapableInterfaceInInterceptedInvocation = interceptedType
                .GetInterfaces()
                .FirstOrDefault(t => t.HasAttribute<MapExceptionAttribute>());

            if (mapableInterfaceInInterceptedInvocation != null)
            {
                var exceptionMappingAttribute = mapableInterfaceInInterceptedInvocation.GetCustomAttribute<MapExceptionAttribute>();
                var typeMessage = exceptionMappingAttribute.Message;
                var targetExceptionType = exceptionMappingAttribute.TargetException;

                try
                {
                    invocation.Proceed();
                }
                catch(Exception ex) when (ex.GetType() != targetExceptionType)
                {
                    var methodMessage = invocation.Method.GetCustomAttribute<ExceptionMessageAttribute>()?.Message;

                    if (methodMessage != null)
                    {
                        methodMessage = String.Format(methodMessage, invocation.Arguments); 
                    }

                    var exceptionInstance = (Exception)Activator.CreateInstance(targetExceptionType, methodMessage ?? typeMessage, ex);
                }
            }
        }
    }
}
