using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMessageBus.Dto;

namespace TrainingMessageBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IBus _bus;

        public ProducerController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet("sendSimpleMessage")]
        public async Task<IActionResult> SendSimpleMessage(string content, CancellationToken cancellationToken)
        {
            await _bus.Publish(new SimpleMessage() { Content = content }, cancellationToken);
            return Ok($"Message with content: {content} send successfully!");
        }
    }
}
