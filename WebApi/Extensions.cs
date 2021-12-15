using WebApi.Dto;
using System.Collections.Generic;
using WebApi.Entitys;

namespace WebApi
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item Item)
        {
            return new ItemDto
            {
                Id = Item.Id,
                Name = Item.Name,
                Price = Item.Price,
                CreatedDate = Item.CreatedDate
            };
        }
    }
}
