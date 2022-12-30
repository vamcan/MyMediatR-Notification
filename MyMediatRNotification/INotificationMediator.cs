namespace MyMediatRNotification
{
    public interface INotificationMediator
    {
        void Register<T>(INotificationHandler<T> handler) where T : INotification;
        Task Publish<T>(T notification) where T : INotification;
    }
}
