using Microsoft.AspNetCore.Mvc;
using SubscribersAPI.DTOs;
using SubscribersAPI.Models;
using SubscribersAPI.Services;

namespace SubscribersAPI.Controllers
{
    [Route("api/subscribers")]
    [ApiController]
    public class SubscribersController(ISubscriberService subService) : ControllerBase
    {
        private readonly ISubscriberService subscriberService = subService;
        [HttpGet]
        public async Task<IActionResult> GetAllSubscribers()
        {
            return Ok(await subscriberService.GetAllSubscribersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriberById([FromRoute] int id)
        {
            var sub = await subscriberService.GetSubscriberByIdAsync(id);
            if (sub is null)
                return NotFound("Subscriber Not Found");

            return Ok(sub);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubscriber([FromBody] CreateSubscriberDTO sub)
        {
            var createdSub = await subscriberService.CreateSubscriberAsync(sub);

            return Ok(createdSub);
        }
        [HttpPatch("{id}/channel")]
        public async Task<IActionResult> AddChannelToSubscriber([FromRoute] int id, [FromBody] AddChannelDto channel)
        {
            var sub = await subscriberService.AddChannelToUserAsync(id, channel);
            if (sub is null)
                return NotFound("Subscriber Not Found");

            return Ok(sub);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscriber([FromRoute] int id, [FromBody] UpdateSubscriberDTO subInfo)
        {
            var sub = await subscriberService.UpdateSubscriberAsync(id, subInfo);
            if (sub is null)
                return NotFound("Subscriber Not Found");

            return Ok(sub);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber([FromRoute] int id)
        {
            var isDeleted = await subscriberService.DeleteSubscriberAsync(id);
            if (!isDeleted)
                return NotFound("Subscriber Not Found");

            return NoContent();
        }
    }
}
