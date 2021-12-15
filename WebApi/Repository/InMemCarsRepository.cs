using WebApi.Entitys;

namespace WebApi.Repository
{
    public class InMemCarsRepository : IItemsRepository<Car>
    {
        private readonly List<Car> cars = new()
        {
            new Car { Id = Guid.NewGuid(), Mark = "BMW", Price = 100000, CreatedDate = DateTime.UtcNow },
            new Car { Id = Guid.NewGuid(), Mark = "Mercedes", Price = 120000, CreatedDate = DateTime.UtcNow },
            new Car { Id = Guid.NewGuid(), Mark = "Ferarri", Price = 150000, CreatedDate = DateTime.UtcNow },
            new Car { Id = Guid.NewGuid(), Mark = "ZAZ", Price = 500, CreatedDate = DateTime.UtcNow },
            new Car { Id = Guid.NewGuid(), Mark = "Audi", Price = 200000, CreatedDate = DateTime.UtcNow }
        };

        public IEnumerable<Car> GetItems() => cars;
        public Car GetItem(Guid id) => cars.SingleOrDefault(car => car.Id == id);

    }
}