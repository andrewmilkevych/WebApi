using System;
namespace WebApi.Entitys
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string? Mark { get; init; }
        public int Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
