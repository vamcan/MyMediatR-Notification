namespace MyMediatRNotification
{
    public interface INotificationHandler<in T> where T : INotification
    {
        Task Handle(T notification);
    }
}
