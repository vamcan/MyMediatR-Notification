using Moq;

namespace MyMediatRNotification.Tests
{
    public class NotificationMediatorTests
    {
        [Fact]
        public async void CanPublishNotification()
        {
            // Arrange
            var notificationMediator = new NotificationMediator();
            var sampleNotification = new SampleNotification();
            var mockNotificationHandler = new Mock<INotificationHandler<SampleNotification>>();
            mockNotificationHandler.Setup(x => x.Handle(sampleNotification)).Returns(Task.CompletedTask);
            notificationMediator.Register(mockNotificationHandler.Object);

            // Act
            await notificationMediator.Publish(sampleNotification);

            // Assert
            mockNotificationHandler.Verify(x => x.Handle(sampleNotification), Times.Once());

        }
    }

    public class SampleNotification : INotification
    {
        // Add properties and methods as needed
    }

    public class SampleNotificationHandler : INotificationHandler<SampleNotification>
    {
        public Task Handle(SampleNotification notification)
        {
            // Perform some action when the notification is received
            return Task.CompletedTask;
        }
    }

}