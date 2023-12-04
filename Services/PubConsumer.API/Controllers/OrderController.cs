using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace PubConsumer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICardService _cardService;

        public OrderController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("post-order")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await _cardService.SendCardTransferInformation("Icard_Stock_IN", order);
            return Ok();
        }
    }
}
