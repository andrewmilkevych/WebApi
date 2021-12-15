using System;
namespace WebApi.Dto
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
