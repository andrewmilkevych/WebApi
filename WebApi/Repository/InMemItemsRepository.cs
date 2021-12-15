using WebApi.Entitys;

namespace WebApi.Repository
{
    public class InMemItemsRepository : IItemsRepository<Item>
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "BMW", Price = 100000, CreatedDate = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Mercedes", Price = 120000, CreatedDate = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Ferarri", Price = 150000, CreatedDate = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "ZAZ", Price = 500, CreatedDate = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Audi", Price = 200000, CreatedDate = DateTime.UtcNow }
        };

        public IEnumerable<Item> GetItems() => items;
        public Item GetItem(Guid id) => items.SingleOrDefault(Items => Items.Id == id);

        public void CreateItem(Item items)
        {
            this.items.Add(items);
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
    }
}