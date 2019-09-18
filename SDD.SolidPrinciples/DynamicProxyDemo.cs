using System;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SDD.SolidPrinciples
{
    public static class DynamicProxyDemo
    {
        public static void Run()
        {
            // Register
            var container = new WindsorContainer();
            container.Register(Component.For<LoggingInterceptor>().LifestyleTransient());
            container.Register(Component.For<DoSomething>().LifestyleTransient());

            // Resolve
            var worker = container.Resolve<DoSomething>();
            worker.Execute();
        }
    }

    [Interceptor(typeof(LoggingInterceptor))]
    public class DoSomething
    {
        public virtual void Execute()
        {
            Console.WriteLine("I'm working hard...");
        }
    }

    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}