using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyMediatRNotification
{
    public static class ServiceRegistrar
    {
        
        public static void AddMyNotificationHandler(this IServiceCollection services, Assembly assembly)
        {
            var notificationMediator = new NotificationMediator();
            var notificationHandlerTypes = assembly
                .GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

            foreach (var notificationHandlerType in notificationHandlerTypes)
            {
               // var notificationType = notificationHandlerType.GetInterfaces().First().GetGenericArguments().First();
               // notificationMediator.Register((INotificationHandler<INotification>)Activator.CreateInstance(notificationHandlerType)!);
               // notificationMediator.Register<INotification>(notificationHandlerType);
            }

            services.AddSingleton(notificationMediator);
        }
    }
}
