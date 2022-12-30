using MyMediatRNotification;

namespace WebApp.Notification
{
    public class UserCreatedNotification : INotification
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
