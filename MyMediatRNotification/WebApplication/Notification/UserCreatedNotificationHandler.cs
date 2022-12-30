using MyMediatRNotification;

namespace WebApp.Notification
{
    public class UserCreatedNotificationHandler : INotificationHandler<UserCreatedNotification>
    {
        public async Task Handle(UserCreatedNotification notification)
        {
            // Perform some action when a UserCreatedNotification is received
            
        }
    }
}
