using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.Entitys;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IItemsRepository<Car> repository;
        public CarsController() => repository = new InMemCarsRepository();
        [HttpGet]
        public IEnumerable<ItemDto> GetCars() => repository.GetItems().Select(item => new ItemDto
        {
            Id = item.Id,  
            Mark = item.Mark, 
            Price = item.Price,
            CreatedDate = item.CreatedDate
        });

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(Guid id)
        {
            var Car = repository.GetItem(id);
            if (Car is null) { NotFound(); }
            return Car;
        }
    }
}