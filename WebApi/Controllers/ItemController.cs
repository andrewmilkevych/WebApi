using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.Entitys;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsRepository<Item> repository;
        public ItemController() => repository = new InMemItemsRepository();

        [HttpGet]
        public IEnumerable<ItemDto> GetItems() => repository.GetItems().Select(item => item.AsDto());

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var Items = repository.GetItem(id);
            if (Items is null) { NotFound(); }
            return Items.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);
            return CreatedAtAction(nameof(CreateItem), new { id = item.Id }, item.AsDto());
        }
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null) { return NotFound(); }
            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            repository.UpdateItem(updatedItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if( existingItem is null) { return NotFound(); }
            repository.DeleteItem(id);
            return NoContent();

        }
    }
}