using Microsoft.AspNetCore.Mvc;
using MyMediatRNotification;
using WebApp.Notification;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationTestController : Controller
    {
        private readonly NotificationMediator _mediator;


        public NotificationTestController(NotificationMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("SendNotificationWithoutServiceCollectionRegistry")]
        public async Task<IActionResult> SendNotificationWithoutServiceCollectionRegistry()
        {
            // Create a notification mediator
            var mediator = new NotificationMediator();

            // Register a notification handler
            mediator.Register(new UserCreatedNotificationHandler());

            // Create and publish a notification
            await mediator.Publish(new UserCreatedNotification
            {
                Email = "Reza@example.com",
                Password = "password"
            });
            return Ok();
        }



        [HttpGet("SendNotification")]
        public async Task<IActionResult> SendNotification()
        {
           
            // Create and publish a notification
            await _mediator.Publish(new UserCreatedNotification
            {
                Email = "Reza@example.com",
                Password = "password"
            });
            return Ok();
        }
    }
}
