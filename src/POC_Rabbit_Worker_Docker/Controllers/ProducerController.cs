using Microsoft.AspNetCore.Mvc;
using Rabbit.Consumer.DTOs.Consumer;
using Rabbit.Producer.Interfaces.Producer;

namespace POC_Rabbit_Worker_Docker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IPixProducer _pixProducer;

        public ProducerController(IPixProducer pixProducer)
        {
            _pixProducer = pixProducer;
        }

        [HttpPost]
        public async Task<IActionResult> Producer([FromBody] PixTransfer pixProducerRequest)
        {
            await _pixProducer.Producer(pixProducerRequest);

            return Ok();
        }
    }
}