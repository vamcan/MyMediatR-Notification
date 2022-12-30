using System.Collections.Concurrent;

namespace MyMediatRNotification
{
    public class NotificationMediator : INotificationMediator
    {
        private readonly ConcurrentDictionary<Type, List<object>> _handlers = new ConcurrentDictionary<Type, List<object>>();

        public void Register<T>(INotificationHandler<T> handler) where T : INotification
        {
            var notificationType = typeof(T);
            if (!_handlers.ContainsKey(notificationType))
            {
                _handlers[notificationType] = new List<object>();
            }
            _handlers[notificationType].Add(handler);
        }

        public async Task Publish<T>(T notification) where T : INotification
        {
            var notificationType = typeof(T);
            if (_handlers.ContainsKey(notificationType))
            {
                foreach (INotificationHandler<T> handler in _handlers[notificationType])
                {
                    await handler.Handle(notification);
                }
            }
        }
    }
}
