using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyMediatRNotification
{
    public static class ServiceRegistrar
    {
        
        public static void AddMyNotificationMediator(this IServiceCollection services, Assembly assembly)
        {
            var notificationMediator = new NotificationMediator();
            var notificationHandlerTypes = assembly
                .GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

            foreach (var notificationHandlerType in notificationHandlerTypes)
            {
                var notificationType = notificationHandlerType.GetInterfaces().First().GetGenericArguments().First();
                var registerMethod = typeof(NotificationMediator).GetMethod("Register").MakeGenericMethod(notificationType);
                registerMethod.Invoke(notificationMediator, new object[] { Activator.CreateInstance(notificationHandlerType) });
            }

            services.AddSingleton<INotificationMediator>(notificationMediator);
        }
    }
}
